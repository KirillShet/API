using KirillApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace KirillApi
{
    public class SensorsContext : DbContext
    {
        public SensorsContext(DbContextOptions<SensorsContext> options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensors>().ToTable("sensor").HasKey(sensor => sensor.sensor_id);
        }
        public DbSet<Sensors> Sensors { get; set; } = null!;
    }
}
