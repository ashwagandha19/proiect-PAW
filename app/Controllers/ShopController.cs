using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
