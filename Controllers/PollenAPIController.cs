using Microsoft.AspNetCore.Mvc;

namespace Gruppe1.Controllers
{
    public class PollenAPIController : Controller
    {
        public IActionResult Index()
        {
            // Her skal vi hente ut og sende viewmodel til visning
            return View();
        }
    }
}