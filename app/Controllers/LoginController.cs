using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
