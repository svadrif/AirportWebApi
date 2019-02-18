using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AirportWebApi.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
        }

        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Route> Routes { get; set; }
    }
}
