using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Proyecto.Extra;
namespace Proyecto.Models.User
{
    public class User
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int _LastId = 1;
        public int Id { get; set; }
        public string UserName { get; set; } = "TestUser";
        public string UserEmail { get; set; } = "TestUserEmail@test.com";
        public string Password { get; set; } = "TestPassword";
        public UserRole UserRole { get; set; } = UserRole.GetUserRole("Client");

        static User()
        {
            _LastId = InitializeId.InitializeIds();
        }
        public User()
        {
            Id = _LastId;
        }

        public User(string username, string password)
        {
            UserName = username;
            Password = password;
            Id = _LastId++;
        }  
    }
    
}
