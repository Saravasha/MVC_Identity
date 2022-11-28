using System.ComponentModel.DataAnnotations;

namespace MVC_Identity.Models
{
    public class PeopleViewModel
    {

        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public List<Language> Languages { get; set; } = new List<Language>(); 
    }
}