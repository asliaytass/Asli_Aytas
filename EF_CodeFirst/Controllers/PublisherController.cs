using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EF_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entities;

namespace Controllers
{
  
    public class PublisherController : Controller
    {
        private readonly Library6Context _context;

        public PublisherController (Library6Context context)
        {
            _context =context;
        }       

        public IActionResult Index()
        {
            return View(_context.Publishers.Where(x=>x.IsDeleted == false).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Publisher publisher )
        {
            _context.Add(publisher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var publisher = _context.Publishers.Find(id);
             return View(publisher);
        }

        [HttpPost,ActionName("Delete")] 
        public IActionResult DeletePublisher(int id)
        {
            var publisher = _context.Publishers.Find(id);
            publisher.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var publisher = _context.Publishers.Find(id);
            return View(publisher);
        }
        
        [HttpPost]
        public IActionResult Edit(Publisher publisher)
        {
            _context.Update(publisher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var publisher = _context.Publishers.Find(id);
            return View(publisher);
        }

    }
}