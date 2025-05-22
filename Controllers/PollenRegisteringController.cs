using Gruppe1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gruppe1.Models;
using System.Linq;

namespace Gruppe1.Controllers
{
    public class PollenRegisteringController : Controller
    {
        private readonly AppDbContext _context;

        public PollenRegisteringController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var registrations = _context.PollenRegistrations.ToList();
            return View(registrations);
        }

        // GET: PollenRegistering/Delete/X
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = _context.PollenRegistrations
                .FirstOrDefault(m => m.ID == id);

            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: PollenRegistering/Delete/X
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var registration = _context.PollenRegistrations.Find(id);
            if (registration != null)
            {
                _context.PollenRegistrations.Remove(registration);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        // GET: PollenRegistering/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PollenRegistering/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PollenRegistering registration)
        {
            if (ModelState.IsValid)
            {
                _context.PollenRegistrations.Add(registration);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(registration);
        }
        // GET: PollenRegistering/Edit/X
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = _context.PollenRegistrations.Find(id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: PollenRegistering/Edit/X
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PollenRegistering registration)
        {
            if (id != registration.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registration);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.PollenRegistrations.Any(e => e.ID == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(registration);
        }
    }
}