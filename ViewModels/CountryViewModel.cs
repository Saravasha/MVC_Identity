using System.ComponentModel.DataAnnotations;
using MVC_Data.Models;

namespace MVC_Data.ViewModels
{
    public class CountryViewModel
    {
        [Required]
        [Display(Name = "Country Name")]
        public string Name { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }
}