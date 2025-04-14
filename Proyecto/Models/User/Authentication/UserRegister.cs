using Newtonsoft.Json;
using Proyecto.CustomAttributes;
using Proyecto.Extra;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.User.Authentication
{
    // Modelo que hereda de Usuario y es usado en el registro de este.
    public class UserRegister : User
    {
        // Campo que tiene que ser Igual al campo Contrasena para que la validacion del registro sea correcta.
        [JsonIgnore]
        [CustomRequired, Compare("Password")]
        public string RePassword { get; set; } = EncryptionMethods.Hash("TestPassword");
    }
}
