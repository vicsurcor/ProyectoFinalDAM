using Newtonsoft.Json;
using Proyecto.Extra;

namespace Proyecto.Models.User
{
    public class SaveFile
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int _LastId = 1;
        public int Id { get; set; }
        public string Name { get; set; } = "TestSave.Json";
        public string Content { get; set; } = "";
        public DateTime SaveTime { get; set; } = DateTime.Now;
        static SaveFile()
        {
            _LastId = InitializeId.InitializeIds();
        }
        public SaveFile() 
        {
            Id = _LastId;
        }

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
