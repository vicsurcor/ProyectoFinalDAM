using Newtonsoft.Json;
using Proyecto.CustomAttributes;
using Proyecto.Extra;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.User.Authentication
{
    public class UserRegister : User
    {
        [JsonIgnore]
        [CustomRequired, Compare("Password")]
        public string RePassword { get; set; } = EncryptionMethods.Hash("TestPassword");
    }
}
