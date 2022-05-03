using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
