using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EF_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entities;

namespace EF_CodeFirst.Controllers
{

    public class CategoryController : Controller
    {
        private readonly Library6Context _context;
        public CategoryController(Library6Context context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View(_context.Categories.Where(x => x.IsDeleted ==false).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost,ActionName("Create")]
        public IActionResult Create(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

       [HttpPost,ActionName("Edit")]
       public IActionResult Edit(Category category)
       {
           if (ModelState.IsValid)
           {
               _context.Update(category);
               _context.SaveChanges();
               return RedirectToAction("Index");
           }
           return View(category);
       }
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteCategory(int id)
        {
            var deleteCategory = _context.Categories.Find(id);
            deleteCategory.IsDeleted =true;            
            _context.SaveChanges();             
            return RedirectToAction("Index");
        }

       


    }
}
