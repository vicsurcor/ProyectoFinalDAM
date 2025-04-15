using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto.Models.User;
using Proyecto.Extra;

namespace Proyecto.Controllers
{
    // Controlador para los archivos de guardado.
    public class SaveController : Controller
    {
        [Route("Saves/add")]
        public IActionResult AddSaveFile(User user, SaveFile saveFile)
        {
            List<UserContent> users = JsonMethods.GetJsonUserContents();

            // Check if the input user matches any user in the list
            foreach (var _user in users)
            {
                if (_user.User.UserName == user.UserName)
                {
                    users[users.IndexOf(_user)].AddSave(saveFile);
                    List<SaveFile> saves = JsonMethods.GetSaveFilesFromJson();
                    saves.Add(saveFile);
                    JsonMethods.UpdateJsonSavesContents(saves);
                    return Ok(new { message = "SaveFile added successfully" });
                }
            }
            return BadRequest();
        }
        // Metodo para la descarga del archivo seleccionado en el View.
        [Route("download/{saveId}")]
        public IActionResult DownloadSaveFile(int saveId)
        {
            var saveFiles = JsonMethods.GetSaveFilesFromJson();
            var saveFile = saveFiles.FirstOrDefault(s => s.Id == saveId);
            if (saveFile == null)
            {
                return NotFound();
            }

            var fileBytes = System.Text.Encoding.UTF8.GetBytes(saveFile.SerializeSaveFile(saveFile));
            var contentType = "application/octet-stream";
            return File(fileBytes, contentType, saveFile.Name);
        }
    }
}
