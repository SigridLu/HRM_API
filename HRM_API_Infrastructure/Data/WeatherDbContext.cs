using System;
using Microsoft.EntityFrameworkCore;
using RHRM_API_ApplicationCore.Entities;

namespace HRM_API_Infrastructure.Data
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> option) : base(option)
        {
        }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}

