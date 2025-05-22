using Microsoft.AspNetCore.Mvc;
using Gruppe1.Data; // Add this if needed
using System.Linq;

namespace Gruppe1.Controllers
{
    public class PollenAPIController : Controller
    {
        private readonly AppDbContext _context;

        public PollenAPIController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pollenWarnings = _context.IndexInfos
                .OrderBy(i => i.ID) // Erstatt med riktig sortering senere
                .Take(5)
                .ToList();

            return View(pollenWarnings);
        }
    }
}