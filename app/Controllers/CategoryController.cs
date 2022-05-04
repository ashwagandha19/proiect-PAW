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
    public class CategoryController : Controller
    {

        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            IEnumerable<app.Models.Category>? objCategoryList = _categoryService.GetCategories();
            return View(objCategoryList);
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _categoryService.GetCategories().FirstOrDefault(m => m.category_id == id);
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
        public IActionResult Create(app.Models.Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryService.AddCategory(obj);
                _categoryService.Save();
                return RedirectToAction("Index");
            }

            return View(obj);

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _categoryService.GetCategories().Where(x => x.category_id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(app.Models.Category Model)
        {
            var data = _categoryService.GetCategories().Where(x => x.category_id == Model.category_id).FirstOrDefault();
            if (data != null)
            {
                _categoryService.UpdateCategory(data);
                _categoryService.Save();
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
            var categoryFromDb = _categoryService.GetCategories().FirstOrDefault(m => m.category_id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }


        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Category? category = _categoryService.GetCategoriesByCondition(b => b.category_id == id).FirstOrDefault();

            if (category == null)
            {
                return NotFound();
            }

            _categoryService.DeleteCategory(category);
            _categoryService.Save();
            return RedirectToAction("Index");
        }

    }
}
