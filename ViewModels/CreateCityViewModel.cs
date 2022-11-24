using MVC_Data.Models;

namespace MVC_Data.ViewModels
{
    public class CreateCityViewModel
    {
        public CityViewModel NewCity { get; set; } = new CityViewModel();

        public List<City> Cities = new List<City>();

    }
}