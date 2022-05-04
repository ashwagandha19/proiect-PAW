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
    public class BillController : Controller
    {

        private readonly BillService _billService;

        public BillController(BillService billService)
        {
            _billService = billService;
        }

        public IActionResult Index()
        {
            IEnumerable<app.Models.Bill>? objBillList = _billService.GetBills();
            return View(objBillList);
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bill = _billService.GetBills().FirstOrDefault(m => m.bill_id == id);
            if (bill == null)
            {
                return NotFound();
            }
            return View(bill);
        }



        //GET
        public IActionResult Create()
        {
            return View();
        }



        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //avoid xss
        public IActionResult Create(app.Models.Bill obj)
        {
            if (ModelState.IsValid)
            {
                _billService.AddBill(obj);
                _billService.Save();
                return RedirectToAction("Index");
            }

            return View(obj);

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _billService.GetBills().Where(x => x.bill_id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(app.Models.Bill Model)
        {
            var data = _billService.GetBills().Where(x => x.bill_id == Model.bill_id).FirstOrDefault();
            if (data != null)
            {
                _billService.UpdateBill(data);
                _billService.Save();
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
            var billFromDb = _billService.GetBills().FirstOrDefault(m => m.bill_id == id);

            if (billFromDb == null)
            {
                return NotFound();
            }

            return View(billFromDb);
        }


        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Bill? bill = _billService.GetBillsByCondition(b => b.bill_id == id).FirstOrDefault();

            if (bill == null)
            {
                return NotFound();
            }

            _billService.DeleteBill(bill);
            _billService.Save();
            return RedirectToAction("Index");
        }

    }
}
