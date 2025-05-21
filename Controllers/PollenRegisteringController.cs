using Gruppe1.Data;
using Microsoft.AspNetCore.Mvc;
using Gruppe1.Models;

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
    }
}