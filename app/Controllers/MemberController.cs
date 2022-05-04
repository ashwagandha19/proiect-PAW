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
    public class MemberController : Controller
    {

        private readonly MemberService _memberService;

        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
        }

        public IActionResult Index()
        {
            IEnumerable<app.Models.Member>? objMemberList = _memberService.GetMembers();
            return View(objMemberList);
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var member = _memberService.GetMembers().FirstOrDefault(m => m.member_id == id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }



        //GET
        public IActionResult Create()
        {
            return View();
        }



        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //avoid xss
        public IActionResult Create(app.Models.Member obj)
        {
            if (ModelState.IsValid)
            {
                _memberService.AddMember(obj);
                _memberService.Save();
                return RedirectToAction("Index");
            }

            return View(obj);

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _memberService.GetMembers().Where(x => x.member_id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(app.Models.Member Model)
        {
            var data = _memberService.GetMembers().Where(x => x.member_id == Model.member_id).FirstOrDefault();
            if (data != null)
            {
                _memberService.UpdateMember(data);
                _memberService.Save();
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
            var memberFromDb = _memberService.GetMembers().FirstOrDefault(m => m.member_id == id);

            if (memberFromDb == null)
            {
                return NotFound();
            }

            return View(memberFromDb);
        }


        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Member? member = _memberService.GetMembersByCondition(b => b.member_id == id).FirstOrDefault();

            if (member == null)
            {
                return NotFound();
            }

            _memberService.DeleteMember(member);
            _memberService.Save();
            return RedirectToAction("Index");
        }

    }
}
