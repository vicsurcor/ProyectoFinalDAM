using Newtonsoft.Json;
using Proyecto.Models.User;

namespace Proyecto.Extra
{
    // Clase que engloba los metodos Json usados en la app.
    public class JsonMethods
    {
        // Path para los archivos de guardado de la api.
        public static readonly string filePath = "TestData/DataStartUsers.json";
        public static readonly string savePath = "TestData/DataStartSaves.json";

        // Metodo para devolver la lista de usuarios registrados.
        public static List<UserContent> GetJsonUserContents()
        {
            
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
           

            return JsonConvert.DeserializeObject<List<UserContent>>(json); ;
        }

        // Metodo para actualizar la list de usuarios de la api.
        public static void UpdateJsonUserContents(List<UserContent> users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(json);
                Console.WriteLine("File overwritten successfully.");
            }
        }

        // Metodo para devolver la lista de archivos de guardado de la api.
        public static List<SaveFile> GetSaveFilesFromJson()
        {
            var jsonFilePath = savePath;
            var jsonData = System.IO.File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<SaveFile>>(jsonData);
        }
    }
}
