using Newtonsoft.Json;

namespace Proyecto.Models.User
{
    public class SaveFile
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "TestSave.Json";
        public string Content { get; set; } = "";
        public DateTime SaveTime { get; set; } = DateTime.Now;

        public SaveFile() { }

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
