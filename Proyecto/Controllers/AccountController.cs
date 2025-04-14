using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto.Models.User;
using Proyecto.Extensions;
using Proyecto.Extra;
using Proyecto.Models.User.Authentication;

namespace Proyecto.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        #region Select
        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet("[action]")]
        public IActionResult Register()
        {
            return View();
        }
        #endregion

        #region Insert
        [HttpPost("[action]")]
        public IActionResult Login(User user)
        {
            // Deserialize the JSON to a list of users
            List<UserContent> users = JsonMethods.GetJsonUserContents();

            // Check if the input user matches any user in the list
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
