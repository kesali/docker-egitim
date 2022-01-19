using System;
using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Data
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> dbContext) : base(dbContext)
        {
        }

        public DbSet<WeatherForecast> Weathers { get; set; }
    }
}
