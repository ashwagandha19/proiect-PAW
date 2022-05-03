using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
