using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Data;
using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        //Index Get
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationTypes;
            return View(objList);
        }
        //Create Get
        public IActionResult Create()
        {
            return View();
        }
        //Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }
        //Edit Get
        public IActionResult Edit(int? Id)
        {
            if (Id == null && Id == 0)
                return NotFound();
            
            var obj = _db.ApplicationTypes.Find(Id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }
        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Delete Get
        public IActionResult Delete(int? Id)
        {
            if (Id == null && Id == 0)
                return NotFound();

            var obj = _db.ApplicationTypes.Find(Id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }
        //Delete Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            if (Id == null && Id == 0)
                return NotFound();
            
            var obj = _db.ApplicationTypes.Find(Id);

            if (obj == null)
                return NotFound();

            _db.ApplicationTypes.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
