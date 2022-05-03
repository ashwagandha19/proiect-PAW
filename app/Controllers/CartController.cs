using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
