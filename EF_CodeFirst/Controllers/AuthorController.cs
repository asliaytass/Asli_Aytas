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
    public class AuthorController : Controller
    {
        private readonly Library6Context _context;

        public AuthorController(Library6Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Authors.Where(x => x.IsDeleted==false).ToList());
        }

        public IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _context.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");     
       }

       public IActionResult Details(int id)
       {
           var author = _context.Authors.Find(id);
           return View(author);
       }

       public IActionResult Delete(int id)
       {
           var author = _context.Authors.Find(id);
           return View(author);
       }

       [HttpPost, ActionName("Delete")]
       public IActionResult DeleteAuthor(int id)
       {
           var deleteAuthor = _context.Authors.Find(id);
           deleteAuthor.IsDeleted=true;
           _context.SaveChanges();
           return RedirectToAction("Index");

       }
        public IActionResult Edit(int id)
        {
            var author = _context.Authors.Find(id);
            return View(author);
        }
        [HttpPost,ActionName("Edit")]
        public IActionResult Edit(Author author)
        {
            if(ModelState.IsValid)
            {
                _context.Update(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }



       
    }
}