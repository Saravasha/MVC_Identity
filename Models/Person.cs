
namespace MVC_Identity.Models
{
    public class Person
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public int CityId { get; set; }
        public City City { get; set; }

        public List<Language> Languages { get; set; } = new List<Language>();

    }
}
