using Microsoft.AspNetCore.Mvc;
using Proyecto.Models.User;

namespace Proyecto.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("[action]")]
        public IActionResult Login(User user)
        {
            return View();
        }
        [HttpGet("[action]")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("[action]")]
        public IActionResult Register(User user)
        {
            return View();
        }
    }
}
