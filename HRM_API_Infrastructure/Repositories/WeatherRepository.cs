using System;
using HRM_API_ApplicationCore.Contracts.Repositories;
using HRM_API_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using RHRM_API_ApplicationCore.Entities;

namespace HRM_API_Infrastructure.Repositories
{
    // This Repository did not inherit BaseRepository(Infra)
    public class WeatherRepository : IWeatherRepository
    {
        protected readonly WeatherDbContext _dbContext;

        public WeatherRepository(WeatherDbContext context)
        {
            _dbContext = context;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<WeatherForecast>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<WeatherForecast>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllAsync()
        {
            return await _dbContext.Set<WeatherForecast>().ToListAsync();
        }

        public async Task<WeatherForecast> GetByIdAsync(int id)
        {
            return await _dbContext.Set<WeatherForecast>().FindAsync(id);
        }

        public async Task<int> InsertAsync(WeatherForecast entity)
        {
            _dbContext.Set<WeatherForecast>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> UpdateAsync(WeatherForecast entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
}

