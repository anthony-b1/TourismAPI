using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TourismAPI.Models;

namespace TourismAPI.Models
{
    public class TourismAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public TourismAPIDBContext(DbContextOptions<TourismAPIDBContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("TourismData");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<TouristAttract> TouristAttractions { get; set; } = null!;
        public DbSet<AttractionDesc> AttractionDescription { get; set; } = null!;
    }
}
