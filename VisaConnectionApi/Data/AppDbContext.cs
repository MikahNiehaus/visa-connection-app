using Microsoft.EntityFrameworkCore;
using VisaConnectionApi.Models; // Ensure this matches the namespace of your model class

namespace VisaConnectionApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CountryRecommendation> CountryRecommendations { get; set; }
    }
}
