using System;
using System.Collections.Generic;
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
            //if (obj.Name == obj.DisplayOrder.ToString()) {
            //    ModelState.AddModelError()
            //}
            if (ModelState.IsValid) { //ModalState checks the validaton in the Model, the validation messegein view is controlled in view
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

            //return View(); To stay in the same view
            //return RedirectToAction("Index", "Category"); to explicitly define
        }
    }
}