using Newtonsoft.Json;
using Proyecto.Extra;

namespace Proyecto.Models.User
{
    // Modelo que engloba los archivos de guardado.
    public class SaveFile
    {
        // Ultima id disponible.
        [Newtonsoft.Json.JsonIgnore]
        public static int _LastId = 1;
        // Id del archivo.
        public int Id { get; set; }
        // Nombre del archivo.
        public string Name { get; set; } = "TestSave.Json";
        // Contenido del archivo.
        public string Content { get; set; } = "";
        // Fecha y hora de realizacion del el guardado.
        public DateTime SaveTime { get; set; } = DateTime.Now;

        // Recuento de Ids al crear un archivo.
        static SaveFile()
        {
            _LastId = InitializeId.InitializeSaveFileIds();
        }
        public SaveFile() 
        {
            Id = _LastId;
        }

        // Metodos Json.
        #region Json
        public SaveFile DeserializeSaveFile(string json)
        {
            if (json != null)
            {
                var obj = JsonConvert.DeserializeObject<SaveFile>(json);
                Id = obj.Id;
                Name = obj.Name;
                Content = obj.Content;
                SaveTime = obj.SaveTime;
                return obj;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        public string SerializeSaveFile(SaveFile save)
        {
            if (save != null)
            {
                return JsonConvert.SerializeObject(save);
                
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        #endregion

        //Metodos Auxiliares.
        #region Aux
        public string GetName()
        {
            return Name;
        }
        public string GetContent()
        {
            return Content;
        }
        public DateTime GetSaveDate()
        {
            return SaveTime;
        }
        #endregion

    }
}
