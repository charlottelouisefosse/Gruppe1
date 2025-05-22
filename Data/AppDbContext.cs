using Microsoft.EntityFrameworkCore;
using Gruppe1.Models;

namespace Gruppe1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ColorInfo> ColorInfos { get; set; }
        public DbSet<DateInfo> DateInfos { get; set; }
        public DbSet<IndexInfo> IndexInfos { get; set; }
        public DbSet<PlantInfo> PlantInfos { get; set; }
        public DbSet<PollenResponse> PollenResponses { get; set; }
        public DbSet<PollenRegistering> PollenRegistrations { get; set; }
    }
}