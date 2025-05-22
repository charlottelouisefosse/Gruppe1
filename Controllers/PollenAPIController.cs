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

    public async Task<IActionResult> Index()
    {
        // Hent JSON fra ekstern API via tjenesten
        var json = await _pollenService.GetPollenForecastAsync();

        // Deserialiser JSON til PollenAPIResponse
        var APIResponse = JsonSerializer.Deserialize<PollenAPIResponse>(json);

        // Hent fargeinformasjon fra databasen
        var indexInfos = await _context.IndexInfos
            .Include(i => i.ColorInfo)
            .ToListAsync();

        int id = 1;
        // Bygg listen av ViewModel
        var tabell = new List<ViewModelPollen>();

        if (APIResponse?.dailyInfo != null)
        {
            foreach (var day in APIResponse.dailyInfo)
            {
                if (day.pollenTypeInfo != null)
                {
                    foreach (var pollen in day.pollenTypeInfo)
                    {
                        int red = (int)((pollen.indexInfo?.color?.red ?? 0) * 255);
                        int green = (int)((pollen.indexInfo?.color?.green ?? 0) * 255);
                        int blue = (int)((pollen.indexInfo?.color?.blue ?? 0) * 255);

                        tabell.Add(new ViewModelPollen
                        {
                            ID = id++,
                            Date = day.date != null ? $"{day.date.day:D2}.{day.date.month:D2}.{day.date.year}" : "",
                            Code = pollen.code,
                            DisplayName = pollen.displayName,
                            Value = pollen.indexInfo?.value ?? 0,
                            Category = pollen.indexInfo?.category ?? "",
                            IndexDescription = pollen.indexInfo?.indexDescription ?? "",
                            ColorHex = $"#{red:X2}{green:X2}{blue:X2}",
                            Red = red,
                            Green = green,
                            Blue = blue
                        });
                    }
                }
            }
        }

        return View(tabell);
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
                DateTime dateValue = default;
                if (item.date != null)
                    dateValue = new DateTime(item.date.year, item.date.month, item.date.day);

                if (item.pollenTypeInfo != null)
                {
                    foreach (var pollen in item.pollenTypeInfo)
                    {
                        var entity = new PollenRegistering
                        {
                            Date = dateValue,
                            TypeOfPollen = pollen.code,
                            Level = pollen.indexInfo?.value ?? 0
                        };
                        _context.PollenRegistrations.Add(entity);
                    }
                }
            }
            await _context.SaveChangesAsync();
        }

        return Content("Data importert og lagret!", "text/plain");
    }
}