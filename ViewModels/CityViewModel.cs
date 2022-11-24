using System.ComponentModel.DataAnnotations;
using MVC_Data.Models;

namespace MVC_Data.ViewModels
{
    public class CityViewModel
    {

        [Required]
        [Display(Name = "City Name")]
        public string Name { get; set; }

        public int CountryId { get; set; }
        
    }
}
