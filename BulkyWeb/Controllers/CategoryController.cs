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
    }
}