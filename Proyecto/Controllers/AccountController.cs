using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto.Models.User;
using Proyecto.Extensions;
using Proyecto.Extra;
using Proyecto.Models.User.Authentication;

namespace Proyecto.Controllers
{
    // Controlador para la gestion del Usuario.
    [Route("[controller]")]
    public class AccountController : Controller
    {

        #region Select

        // Accede a la pagina de Login.
        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return View();
        }
        // Accede a la pagina de registro.
        [HttpGet("[action]")]
        public IActionResult Register()
        {
            return View();
        }
        #endregion

        #region Insert

        // Recoge los datos del formulario, verifica que el usuario existe y las credenciales son correctas, establece el Usuario en la sesion y accede a la pagina de Stats.
        // En caso de fallo, muestra los errores de validacion del formulario.
        [HttpPost("[action]")]
        public IActionResult Login(User user)
        {
            List<UserContent> users = JsonMethods.GetJsonUserContents();

            foreach (var _user in users)
            {
                if (_user.User.UserName == user.UserName && EncryptionMethods.VerifyHash(user.Password, _user.User.Password))
                {
                    UserViewModel view = new UserViewModel(_user.User, _user);
                    HttpContext.Session.SetObject("UserModel", view);
                    return RedirectToAction("Index", "Stats");
                }
            }
            return View();
        }

        // Recoge los datos del formulario, verifica que el usuario no existe y las contrasenas coinciden, anade el Usuario al archivo y accede a la pagina de Login.
        // En caso de fallo, muestra los errores de validacion del formulario.
        [HttpPost("[action]")]
        public IActionResult Register(UserRegister user)
        {

            // Deserialize the JSON to a list of users
            List<UserContent> users = JsonMethods.GetJsonUserContents();

            // Check if the input user matches any user in the list
            foreach (var _user in users)
            {
                if (_user.User.UserName == user.UserName)
                {
                    return View();
                }
                else if (!ModelState.IsValid)
                {
                    return View(user);
                }
                else
                {
                    users.Add(new UserContent(new User(
                        user.UserName,
                        user.UserEmail,
                        user.Password
                        )));
                    JsonMethods.UpdateJsonUserContents(users);
                    return RedirectToAction("Login", "Account");
                }
            }
            
            return View();

        }

        #endregion
    }
}
