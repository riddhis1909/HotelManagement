using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.WebApi.Models.CountryModels
{
    public class GetCountryModel
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; } = null!;

        public bool IsCountryActive { get; set; }

        public bool IsCountryDeleted { get; set; }
    }
}
