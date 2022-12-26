using dataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace dataLayer.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Sensor> Sensor { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<SensorData> SensorData { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().HasData(new Region
            {
                Id = 1,
                Name = "Ludvinono",
            });
            modelBuilder.Entity<Sensor>().HasData(new Sensor
            {
                Id = 1,
                Name = "TMP-1",
                RegionId = 1,
                Lat = 54.570718f,
                Lon = 27.276984f
            });
            modelBuilder.Entity<SensorData>().HasData(new SensorData
            {
                Id = 1,
                SensorId = 1,
                Date = new DateTime(2022, 12, 26),
                Temperature = -3
            });
            modelBuilder.Entity<SensorData>().HasData(new SensorData
            {
                Id = 2,
                SensorId = 1,
                Date = new DateTime(2022, 12, 27),
                Temperature = 2
            });
            modelBuilder.Entity<SensorData>().HasData(new SensorData
            {
                Id = 3,
                SensorId = 1,
                Date = new DateTime(2022, 12, 28),
                Temperature = 1
            });
            modelBuilder.Entity<SensorData>().HasData(new SensorData
            {
                Id = 4,
                SensorId = 1,
                Date = new DateTime(2022, 12, 29),
                Temperature = 1
            });
        }
    }
}
