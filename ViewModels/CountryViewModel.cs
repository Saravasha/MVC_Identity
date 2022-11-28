using System.ComponentModel.DataAnnotations;

namespace MVC_Identity.Models
{
    public class CountryViewModel
    {
        [Required]
        [Display(Name = "Country Name")]
        public string Name { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }
}