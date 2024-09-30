using DigiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiProject
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Weather> WeatherForecast { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weather>()
             .HasKey(w => w.Id);

            modelBuilder.Entity<Weather>()
                .Property(w => w.Id).ValueGeneratedNever();

            modelBuilder.Entity<Weather>()
                .OwnsOne(w => w.Hourly_units, sa =>
                {
                    sa.Property(p => p.Time).HasColumnType("varchar(50)");
                    sa.Property(p => p.Temperature_2m).HasColumnType("varchar(50)");
                });

            modelBuilder.Entity<Weather>()
                .OwnsOne(w => w.Hourly, sa =>
                {
                    sa.Property(p => p.Time).HasColumnType("varchar(max)");
                    sa.Property(p => p.Temperature_2m).HasColumnType("varchar(max)");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
