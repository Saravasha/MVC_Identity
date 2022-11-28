using System.ComponentModel.DataAnnotations;

namespace MVC_Identity.Models
{
    public class CityViewModel
    {

        [Required]
        [Display(Name = "City Name")]
        public string Name { get; set; }

        public int CountryId { get; set; }
        
    }
}
