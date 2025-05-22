using Gruppe1.Models;
using Gruppe1.Data;
using Gruppe1.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=pollen.db"));

// Legger til services for PollenAPI
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient(); // Nødvendig for HttpClient
builder.Services.AddHttpClient<IPollenAPIService, PollenAPIService>();

var app = builder.Build();

// Konfigurerer HTTP forespørsel
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
