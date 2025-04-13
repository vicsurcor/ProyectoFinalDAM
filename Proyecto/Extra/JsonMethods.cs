using Newtonsoft.Json;
using Proyecto.Models.User;

namespace Proyecto.Extra
{
    public class JsonMethods
    {
        // Path to the JSON file
        public static readonly string filePath = "TestData/DataStartUsers.json";
        public static readonly string savePath = "TestData/DataStartSaves.json";
        public static List<UserContent> GetJsonUserContents()
        {
            // Read the JSON file
            string json = "";
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
            /*File.ReadAllText(filePath);*/

            // Deserialize the JSON to a list of users
            List<UserContent> users = JsonConvert.DeserializeObject<List<UserContent>>(json);
            return users;
        }
        public static void UpdateJsonUserContents(List<UserContent> users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(json);
                Console.WriteLine("File overwritten successfully.");
            }
        }
        public static List<SaveFile> GetSaveFilesFromJson()
        {
            var jsonFilePath = savePath;
            var jsonData = System.IO.File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<SaveFile>>(jsonData);
        }
    }
}
