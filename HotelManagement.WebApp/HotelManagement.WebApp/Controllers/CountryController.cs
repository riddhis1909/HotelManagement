using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using HotelManagement.Services;
using HotelManagement.Services.IService;
using HotelManagement.WebApi.Models.CountryModels;
using HotelManagement.WebApi.Models.RoleModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [TranslateResultToActionResult]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly ILogger _logger;

        public CountryController(ICountryService countryService, ILogger<CountryController> logger)
        {
            _countryService = countryService;
            _logger = logger;
        }

        [HttpGet("GetCountries")]
        public async Task<Result<List<GetCountryModel>>> GetCountries()
        {
            try
            {
                _logger.LogInformation("Controller : GetCountries method started");

                var result = await _countryService.GetCountriesService();

                _logger.LogInformation("Controller : GetCountries method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : GetCountries method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        [HttpPut("EditCountry")]
        public async Task<Result> EditCountry(EditCountryModel editCountryRequestModel)
        {
            try
            {
                _logger.LogInformation("Controller : EditCountry method started");

                var result = await _countryService.EditCountryService(editCountryRequestModel);

                _logger.LogInformation("Controller : EditCountry method ended");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : EditCountry method Error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }
    }
}
