using Ardalis.Result;
using HotelManagement.Repositories;
using HotelManagement.Repositories.IRepository;
using HotelManagement.Services.IService;
using HotelManagement.WebApi.Models.CountryModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger _logger;

        public CountryService(ICountryRepository countryRepository, ILogger<CountryService> logger)
        {
            _countryRepository = countryRepository;
            _logger = logger;
        }

        public async Task<Result<List<GetCountryModel>>> GetCountriesService()
        {
            try
            {
                _logger.LogInformation("Service : GetCountriesService started");

                var serviceResponse = await _countryRepository.GetCountries();

                _logger.LogInformation("Service : GetCountriesService completed");
                return serviceResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : GetCountriesService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> EditCountryService(EditCountryModel editCountryRequestModel)
        {
            try
            {
                _logger.LogInformation("Service : EditCountryService started");

                var serviceResponse = await _countryRepository.EditCountry(editCountryRequestModel);

                _logger.LogInformation("Service : EditCountryService completed");
                return serviceResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Service : EditCountryService encountered an error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }
    }
}
