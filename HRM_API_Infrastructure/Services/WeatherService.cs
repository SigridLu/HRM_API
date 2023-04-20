using System;
using HRM_API_ApplicationCore.Contracts.Repositories;
using HRM_API_ApplicationCore.Contracts.Services;
using HRM_API_ApplicationCore.Models;
using HRM_API_Infrastructure.Helpers;
using HRM_API_Infrastructure.Repositories;
using RHRM_API_ApplicationCore.Entities;
using RHRM_API_ApplicationCore.Exceptions;

namespace HRM_API_Infrastructure.Services
{
    public class WeatherService : IWeatherService
    {
        IWeatherRepository weatherRepository;
        public WeatherService(IWeatherRepository _weatherRepositories)
        {
            weatherRepository = _weatherRepositories;
        }

        public async Task<int> AddWeatherAsync(WeatherResponseModel model)
        {
            WeatherForecast weather = new WeatherForecast();
            if (model != null)
            {
                weather.Id = model.Id;
                weather.Date = model.Date;
                weather.TemperatureC = model.TemperatureC;
                //weather.TemperatureF = model.TemperatureF;
                weather.Summary = model.Summary;
            }
            //returns number of rows affected, typically 1
            return await weatherRepository.InsertAsync(weather);
        }

        public async Task<int> DeleteWeatherAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await weatherRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<WeatherResponseModel>> GetAllWeathers()
        {
            var weathers = await weatherRepository.GetAllAsync();
            var response = weathers.Select(x => x.ToWeatherResponseModel());
            return response;
        }

        public async Task<WeatherResponseModel> GetWeatherByIdAsync(int id)
        {
            var weather = await weatherRepository.GetByIdAsync(id);
            if (weather != null)
            {
                var response = weather.ToWeatherResponseModel();
                return response;
            }
            else
            {
                throw new NotFoundException("Candidate", id);
            }
        }

        public async Task<int> UpdateWeatherAsync(WeatherResponseModel model)
        {
            var existingWeather = await weatherRepository.GetByIdAsync(model.Id);
            if (existingWeather == null)
            {
                throw new Exception("Weather Info does not exist");
            }
            WeatherForecast weather = new WeatherForecast();
            if (model != null)
            {
                weather.Id = model.Id;
                weather.Date = model.Date;
                weather.TemperatureC = model.TemperatureC;
                //weather.TemperatureF = model.TemperatureF;
                weather.Summary = model.Summary;
                return await weatherRepository.UpdateAsync(weather);
            }
            else
            {
                //unsuccessful update
                return -1;
            }
        }
    }
}

