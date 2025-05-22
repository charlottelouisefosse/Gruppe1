using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Gruppe1.Service;
using Gruppe1.Models;
using Gruppe1.Data;
using Gruppe1.Models.PollenAPI;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class PollenAPIController : Controller
{
    private readonly IPollenAPIService _pollenService;
    private readonly AppDbContext _context;

    public PollenAPIController(IPollenAPIService pollenService, AppDbContext context)
    {
        _pollenService = pollenService;
        _context = context;
    }
    public IActionResult Index()
    {
        var indexInfos = _context.IndexInfos
            .Include(i => i.ColorInfo)
            .ToList();
        return View(indexInfos);
    }
    public async Task<IActionResult> Import()
    {
        var json = await _pollenService.GetPollenForecastAsync();

        // 1. Deserialisering av JSON
        var APIResponse = JsonSerializer.Deserialize<PollenAPIResponse>(json);

        // 2. Kartlegging av data og lagring i databasen
        if (APIResponse != null && APIResponse.dailyInfo != null)
        {
            foreach (var item in APIResponse.dailyInfo)
            {
                var entity = new PollenRegistering
                {
                    Date = !string.IsNullOrEmpty(item.date) && DateTime.TryParse(item.date, out var parsedDate) ? parsedDate : default,
                    TypeOfPollen = item.pollenType,
                    Level = item.index
                };
                _context.PollenRegistrations.Add(entity);
            }
            await _context.SaveChangesAsync();
        }

        return Content("Data importert og lagret!", "text/plain");
    }
}