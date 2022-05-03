using app.Models;
using library.Data;
using library.Service;
using library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

namespace library.Controllers
{
    public class BookController : Controller
    {
        //private readonly ApplicationDbContext _db;

        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            //_db = db;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            IEnumerable<app.Models.Book>? objBookList = _bookService.GetBooks();
            return View(objBookList);
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _bookService.GetBooks().FirstOrDefault(m => m.book_id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }



        //GET
        public IActionResult Create()
        {
            return View();
        }



        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //avoid xss
        public IActionResult Create(app.Models.Book obj)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(obj);
                _bookService.Save();
                return RedirectToAction("Index");
            }

            return View(obj);

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _bookService.GetBooks().Where(x => x.book_id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(app.Models.Book Model)
        {
            var data = _bookService.GetBooks().Where(x => x.book_id == Model.book_id).FirstOrDefault();
            if (data != null)
            {
                _bookService.UpdateBook(data);
                _bookService.Save();
            }

            return RedirectToAction("index");
        }


        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //get author by id
            var bookFromDb = _bookService.GetBooks().FirstOrDefault(m => m.book_id == id);

            if (bookFromDb == null)
            {
                return NotFound();
            }

            return View(bookFromDb);
        }


        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Book? book = _bookService.GetBooksByCondition(b => b.book_id == id).FirstOrDefault();

            if (book == null)
            {
                return NotFound();
            }

            _bookService.DeleteBook(book);
            _bookService.Save();
            return RedirectToAction("Index");
        }

    }
}
