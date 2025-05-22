using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                .Include(i => i.ColorInfo)
                .OrderBy(i => i.ID)
                .Take(5)
                .ToList();

            return View(pollenWarnings);
        }
    }
}