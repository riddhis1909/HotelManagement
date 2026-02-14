using Ardalis.Result;
using HotelManagement.WebApi.Models.CountryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Repositories.IRepository
{
    public interface ICountryRepository
    {
        Task<Result<List<GetCountryModel>>> GetCountries();

        Task<Result> EditCountry(EditCountryModel editCountryRequestModel);
    }
}
