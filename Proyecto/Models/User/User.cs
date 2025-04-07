using Newtonsoft.Json;

namespace Proyecto.Models.User
{
    public class User
    {
        public int _LastId = 0;
        public string filePath = "TestData/DataStartUsers.json";
        public int Id { get; set; }
        public string UserName { get; set; } = "TestUser";
        public string UserEmail { get; set; } = "TestUserEmail@test.com";
        public string Password { get; set; } = "TestPassword";
        public UserRole UserRole { get; set; } = UserRole.GetUserRole("Client");

        public User() 
        {
            Id = GetLastId();
        }

        public User(string username, string password)
        {
            UserName = username;
            Password = password;
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
                if (_user.User.Id > _LastId)
                {
                    lastId = _user.User.Id;
                }
            }
            return lastId++;
        }
    }
    
}
