using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Proyecto.CustomAttributes;
using Proyecto.Extra;
namespace Proyecto.Models.User
{
    public class User
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int _LastId = 1;
        public int Id { get; set; }
        [CustomRequired]
        public string UserName { get; set; } = "TestUser";
        [CustomRequired]
        public string UserEmail { get; set; } = EncryptionMethods.Hash("TestUserEmail@test.com");
        [CustomRequired]
        public string Password { get; set; } = EncryptionMethods.Hash("TestPassword");
        [JsonIgnore]
        [CustomRequired, Compare("Password")]
        public string RePassword { get; set; } = EncryptionMethods.Hash("TestPassword");
        public UserRole UserRole { get; set; } = UserRole.GetUserRole("Client");

        static User()
        {
            _LastId = InitializeId.InitializeUserIds();
        }
        public User()
        {
            Id = _LastId;
        }

        public User(string username, string password)
        {
            UserName = username;
            Password = EncryptionMethods.Hash(password);
            Id = _LastId++;
        }
        public User(string username, string email, string password, string rePassword)
        {
            UserName = username;
            UserEmail = EncryptionMethods.Hash(email);
            Password = EncryptionMethods.Hash(password);
            RePassword = EncryptionMethods.Hash(rePassword);
            UserRole = UserRole.GetUserRole("Client");    
            Id = _LastId++;
        }
    }
    
}
