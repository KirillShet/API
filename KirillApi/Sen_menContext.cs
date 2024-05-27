using KirillApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace KirillApi
{
    public class Sen_menContext : DbContext
    {
        public Sen_menContext(DbContextOptions<Sen_menContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensors_measurements>().ToTable("sensor_measurements").HasKey(sensor => sensor.type_id);
        }
        public DbSet<Sensors_measurements> Sensors { get; set; } = null!;
    }
}
