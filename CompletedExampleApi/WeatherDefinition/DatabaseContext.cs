using Microsoft.EntityFrameworkCore;

namespace WeatherDefinition
{
    public class DatabaseContext : DbContext
    {
        ModelBuilder _modelBuilder = new ModelBuilder();

        public DbSet<WeatherCondition> WeatherConditions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            optionsBuilder.UseSqlServer(
                @"Server = HAYDEN; Database = TestDB; Trusted_Connection = True; TrustServerCertificate = True");
        }
    }
}
