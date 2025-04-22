using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Proyecto.CustomAttributes;
using Proyecto.Extra;
namespace Proyecto.Models.User
{
    // Modelo que engloba las credenciales del Usuario.
    public class User
    {
        // Ultima id disponible.
        [Newtonsoft.Json.JsonIgnore]
        public static int _LastId = 1;
        // Id del Usuario.
        public int Id { get; set; }
        // Nombre de Usuario.
        [CustomRequired]
        public string UserName { get; set; } = "TestUser";
        // Email del Usuario.
        [CustomRequired]
        public string UserEmail { get; set; } = EncryptionMethods.Hash("TestUserEmail@test.com");
        // Contrasena del Usuario.
        [CustomRequired]
        public string Password { get; set; } = EncryptionMethods.Hash("TestPassword");
        // Rol del Usuario.
        public UserRole UserRole { get; set; } = UserRole.GetUserRole("Client");

        // Recuento de Ids al crear un nuevo Usuario.
        static User()
        {
            _LastId = InitializeId.InitializeUserIds();
        }
        public User()
        {
            Id = _LastId;
        }
        // Constructores de Usuario.
        public User(string username, string password)
        {
            UserName = username;
            Password = EncryptionMethods.Hash(password);
            Id = _LastId++;
        }
        public User(string username, string email, string password)
        {
            UserName = username;
            UserEmail = EncryptionMethods.Hash(email);
            Password = EncryptionMethods.Hash(password);
            UserRole = UserRole.GetUserRole("Client");    
            Id = _LastId++;
        }
    }
    
}
