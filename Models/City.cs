using System.ComponentModel.DataAnnotations;

    namespace MVC_Identity.Models
{
    public class City
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }
        public List<Person> People { get; set; } = new List<Person>();

    }
}