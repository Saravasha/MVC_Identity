namespace MVC_Identity.Models
{
    public class CreateCityViewModel
    {
        public CityViewModel NewCity { get; set; } = new CityViewModel();

        public List<City> Cities = new List<City>();

    }
}