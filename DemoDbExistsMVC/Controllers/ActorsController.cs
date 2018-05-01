using DemoDbExistsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDbExistsMVC.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ActorDbContext _context;
        public ActorsController(ActorDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Actors.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Actors actors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actors);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(actors);
        }
    }
}
