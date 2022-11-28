using System.ComponentModel.DataAnnotations;
namespace MVC_Identity.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; } = new List<Person>();
    }
}
