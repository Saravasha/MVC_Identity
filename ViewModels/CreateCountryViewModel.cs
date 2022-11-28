namespace MVC_Identity.Models
{
    public class CreateCountryViewModel
    {
        public CountryViewModel NewCountry { get; set; } = new CountryViewModel();

        public List<Country> Countries = new List<Country>();

    }
}
