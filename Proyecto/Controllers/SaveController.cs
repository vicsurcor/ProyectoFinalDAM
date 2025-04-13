using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto.Models.User;
using Proyecto.Extra;

namespace Proyecto.Controllers
{
    public class SaveController : Controller
    {
        readonly string SavesPath = JsonMethods.savePath;
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
