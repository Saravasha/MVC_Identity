using System.ComponentModel.DataAnnotations;
using MVC_Data.Models;
namespace MVC_Data.ViewModels
{
	public class LanguageViewModel
	{

        [Display(Name = "Langauge")]
        public string Name { get; set; }
		public List<Person> People { get; set; } = new List<Person>();
	}
}
