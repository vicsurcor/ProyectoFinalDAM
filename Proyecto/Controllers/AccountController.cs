using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto.Models.User;
using Proyecto.Extensions;

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
            // Path to the JSON file
            string filePath = "TestData/DataStartUsers.json";

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

            // Check if the input user matches any user in the list
            foreach (var _user in users)
            {
                if (_user.User.UserName == user.UserName && _user.User.Password == user.Password)
                {
                    UserViewModel view = new UserViewModel(_user.User, _user);
                    HttpContext.Session.SetObject("UserModel", view);
                    return RedirectToAction("Index", "Stats");
                }
            }
            return View();
        }
        [HttpPost("[action]")]
        public IActionResult Register(User user)
        {
            // Path to the JSON file
            string filePath = "TestData/DataStartUsers.json";

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

            // Check if the input user matches any user in the list
            foreach (var _user in users)
            {
                if (_user.User.UserName == user.UserName )
                {
                    return View();
                }
                else
                {
                    users.Add(new UserContent(user));
                    json = JsonConvert.SerializeObject(users, Formatting.Indented);
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.Write(json);
                        Console.WriteLine("File overwritten successfully.");
                    }
                    return View("Login");
                }
            }
            
            return View();

        }
        #endregion
    }
}
