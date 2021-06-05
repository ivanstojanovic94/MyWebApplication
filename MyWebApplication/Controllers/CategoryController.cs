using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Data;
using MyWebApplication.Models;
using System.Collections.Generic;

namespace MyWebApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        //Index Get
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Categories;
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
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
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
            
            var obj = _db.Categories.Find(Id);
            
            if (obj == null)
                return NotFound();
            return View(obj);

        }
        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
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

            var obj = _db.Categories.Find(Id);
            if (obj == null)
                return NotFound();
            return View(obj);
        }
        //Delete Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.Categories.Find(Id);
            if (obj == null)
                return NotFound();

                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }
    }  
}
