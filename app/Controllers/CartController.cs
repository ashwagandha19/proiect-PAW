using library.Service;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class CartController : Controller
    {

        private readonly BookService _bookService;

        public CartController(BookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            IEnumerable<app.Models.Book>? objBookList = _bookService.GetBooks();
            return View(objBookList);
        }
    }
}
