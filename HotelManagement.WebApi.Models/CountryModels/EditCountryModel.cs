using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.WebApi.Models.CountryModels
{
    public class EditCountryModel
    {
        public int CountryID { get; set; }

        public bool IsCountryActive { get; set; }
    }
}
