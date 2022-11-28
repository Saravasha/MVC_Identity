using System.ComponentModel.DataAnnotations;
namespace MVC_Identity.Models
{
	public class LanguageViewModel
	{

        [Display(Name = "Langauge")]
        public string Name { get; set; }
		public List<Person> People { get; set; } = new List<Person>();
	}
}
