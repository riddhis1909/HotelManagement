using Ardalis.Result;
using HotelManagement.DAL.SQL.DBContext;
using HotelManagement.Repositories.IRepository;
using HotelManagement.WebApi.Models.CountryModels;
using HotelManagement.WebApi.Models.RoomStatusModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace HotelManagement.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly HotelManagementContext _dbContext;
        private readonly ILogger _logger;

        public CountryRepository(HotelManagementContext dbContext, ILogger<CountryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Result<List<GetCountryModel>>> GetCountries()
        {
            try
            {
                _logger.LogInformation("Repository : GetCountries method initiated");

                var dbCountryData = await _dbContext.tblCountries.ToListAsync();

                List<GetCountryModel> countryList = new List<GetCountryModel>();

                if (dbCountryData != null)
                {
                    foreach (var country in dbCountryData)
                    {
                        GetCountryModel getCountryModel = new GetCountryModel
                        {
                            CountryID = country.CountryID,
                            CountryName = country.CountryName,
                            IsCountryActive = country.IsCountryActive,
                            IsCountryDeleted = country.IsCountryDeleted
                        };
                        countryList.Add(getCountryModel);
                    }
                    _logger.LogInformation("Repository : GetCountries method completed");
                    return Result.Success(countryList);
                }
                else
                {
                    _logger.LogInformation("Repository : No country found");
                    return Result.NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repository : GetCountries method encountered error: {ex.Message}");
                return Result.Error(ex.Message);
            }
        }

        public async Task<Result> EditCountry(EditCountryModel editCountryRequestModel)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _logger.LogInformation("Repository : EditCountry method initiated");

                    if (editCountryRequestModel == null)
                    {
                        _logger.LogInformation("Repository : EditCountry method found with null editCountryRequestModel");
                        return Result.NoContent();
                    }

                    var dbCountryData = await _dbContext.tblCountries
                        .Include(s => s.tblStates)
                        .Where(item => item.CountryID == editCountryRequestModel.CountryID).FirstOrDefaultAsync();

                    if (dbCountryData != null)
                    {
                        dbCountryData.IsCountryActive = editCountryRequestModel.IsCountryActive;

                        foreach (var state in dbCountryData.tblStates)
                        {
                            state.IsStateActive = editCountryRequestModel.IsCountryActive;
                            state.UpdatedBy = 1;
                            state.UpdatedDate = DateTime.Now;
                        }

                        dbCountryData.UpdatedBy = 1;
                        dbCountryData.UpdatedDate = DateTime.Now;

                        _dbContext.tblCountries.Update(dbCountryData);
                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();

                        _logger.LogInformation("Repository : EditCountry method completed");
                        return Result.Success();
                    }
                    else
                    {
                        _logger.LogInformation("Repository : No country found id {0}", editCountryRequestModel.CountryID);
                        return Result.NotFound();
                    }
                }
                catch (DbException dbEx)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError($"Repository : EditCountry method encountered database error: {dbEx.Message}");
                    return Result.Error(dbEx.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Repository : EditCountry method encountered error: {ex.Message}");
                    return Result.Error(ex.Message);
                }
            }
        }
    }
}
