using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{

    public class CategoryController : Controller
    {
        //accesing the db for operations
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        //accesing the db ends

        public IActionResult Index()
        {
            List<Category> objCategorylist = _db.Categories.ToList();
            return View(objCategorylist);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot match the name");
            }
            if (obj.Name == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value");
            }
            if (ModelState.IsValid) { //ModalState checks the validaton in the Model, the validation messegein view is controlled in view
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id); // Method one
            Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id); // Method two
            Category? categoryFromDb3 = _db.Categories.Where(u => u.Id == id).FirstOrDefault(); // Method three
            return View(categoryFromDb);
        }


        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return View();
        }


        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id); // Method one
            Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id); // Method two
            Category? categoryFromDb3 = _db.Categories.Where(u => u.Id == id).FirstOrDefault(); // Method three
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult DeletePOST(int ? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);  
            _db.Categories.Remove(categoryFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

 
}