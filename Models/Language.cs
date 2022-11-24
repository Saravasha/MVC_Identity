using System.ComponentModel.DataAnnotations;
using MVC_Data.Models;
namespace MVC_Database.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; } = new List<Person>();
    }
}
