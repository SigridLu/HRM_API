using System;
using HRM_API_ApplicationCore.Models;
using RHRM_API_ApplicationCore.Models;

namespace HRM_API_ApplicationCore.Contracts.Services
{
    public interface IWeatherService
    {
        Task<int> AddWeatherAsync(WeatherResponseModel model);
        Task<int> UpdateWeatherAsync(WeatherResponseModel model);
        Task<int> DeleteWeatherAsync(int id);
        Task<WeatherResponseModel> GetWeatherByIdAsync(int id);
        Task<IEnumerable<WeatherResponseModel>> GetAllWeathers();
    }
}

