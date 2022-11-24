using System.ComponentModel.DataAnnotations;
using MVC_Database.Models;

namespace MVC_Data.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; } = new List<City>();

    }
}
 