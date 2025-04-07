using Newtonsoft.Json;

namespace Proyecto.Models.User
{
    public class SaveFile
    {
        public int _LastId = 0;
        public string filePath = "TestData/DataStartUsers.json";
        public int Id { get; set; }
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
        public int GetLastId()
        {
            string json = "";
            int lastId = _LastId;
            try
            {
                using StreamReader reader = new StreamReader(filePath);
                json = reader.ReadToEnd();
                Console.WriteLine("File read successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // Deserialize the JSON to a list of users
            List<UserContent> users = JsonConvert.DeserializeObject<List<UserContent>>(json);

            foreach (var _user in users)
            {
                if (_user.Saves.Count > _LastId)
                {
                    lastId = _user.Saves.Count;
                }
            }
            return lastId++;
        }
        #endregion

    }
}
