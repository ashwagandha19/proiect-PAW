using app.Models;
using library.Data;
using library.Service;
using library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

namespace library.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {

        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            IEnumerable<app.Models.Author>? objAuthorList = _authorService.GetAuthors();
            return View(objAuthorList);
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var author = _authorService.GetAuthors().FirstOrDefault(m => m.author_id == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }



        //GET
        public IActionResult Create()
        {
            return View();
        }



        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //avoid xss
        public IActionResult Create(app.Models.Author obj)
        {
            if (ModelState.IsValid)
            {
                _authorService.AddAuthor(obj);
                _authorService.Save();
                return RedirectToAction("Index");
            }

            return View(obj);

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _authorService.GetAuthors().Where(x => x.author_id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(app.Models.Author Model)
        {
            var data = _authorService.GetAuthors().Where(x => x.author_id == Model.author_id).FirstOrDefault();
            if (data != null)
            {
                _authorService.UpdateAuthor(data);
                _authorService.Save();
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
            var authorFromDb = _authorService.GetAuthors().FirstOrDefault(m => m.author_id == id);

            if (authorFromDb == null)
            {
                return NotFound();
            }

            return View(authorFromDb);
        }


        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Author? author = _authorService.GetAuthorsByCondition(b => b.author_id == id).FirstOrDefault();

            if (author == null)
            {
                return NotFound();
            }

            _authorService.DeleteAuthor(author);
            _authorService.Save();
            return RedirectToAction("Index");
        }

    }
}
