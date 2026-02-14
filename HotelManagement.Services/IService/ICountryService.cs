using Ardalis.Result;
using HotelManagement.WebApi.Models.CountryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Services.IService
{
    public interface ICountryService
    {
        Task<Result<List<GetCountryModel>>> GetCountriesService();

        Task<Result> EditCountryService(EditCountryModel editCountryRequestModel);
    }
}
