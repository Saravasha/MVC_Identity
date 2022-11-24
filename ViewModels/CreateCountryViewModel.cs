using System.ComponentModel.DataAnnotations;
using MVC_Data.Models;
using MVC_Database.Models;

namespace MVC_Data.ViewModels
{
    public class CreateCountryViewModel
    {
        public CountryViewModel NewCountry { get; set; } = new CountryViewModel();

        public List<Country> Countries = new List<Country>();

    }
}
