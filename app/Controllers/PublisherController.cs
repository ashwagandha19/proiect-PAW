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
    public class PublisherController : Controller
    {

        private readonly PublisherService _publisherService;

        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        public IActionResult Index()
        {
            IEnumerable<app.Models.Publisher>? objPublisherList = _publisherService.GetPublishers();
            return View(objPublisherList);
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var publisher = _publisherService.GetPublishers().FirstOrDefault(m => m.publisher_id == id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }



        //GET
        public IActionResult Create()
        {
            return View();
        }



        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //avoid xss
        public IActionResult Create(app.Models.Publisher obj)
        {
            if (ModelState.IsValid)
            {
                _publisherService.AddPublisher(obj);
                _publisherService.Save();
                return RedirectToAction("Index");
            }

            return View(obj);

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _publisherService.GetPublishers().Where(x => x.publisher_id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(app.Models.Publisher Model)
        {
            var data = _publisherService.GetPublishers().Where(x => x.publisher_id == Model.publisher_id).FirstOrDefault();
            if (data != null)
            {
                _publisherService.UpdatePublisher(data);
                _publisherService.Save();
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
            var publisherFromDb = _publisherService.GetPublishers().FirstOrDefault(m => m.publisher_id == id);

            if (publisherFromDb == null)
            {
                return NotFound();
            }

            return View(publisherFromDb);
        }


        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Publisher? publisher = _publisherService.GetPublishersByCondition(b => b.publisher_id == id).FirstOrDefault();

            if (publisher == null)
            {
                return NotFound();
            }

            _publisherService.DeletePublisher(publisher);
            _publisherService.Save();
            return RedirectToAction("Index");
        }

    }
}
