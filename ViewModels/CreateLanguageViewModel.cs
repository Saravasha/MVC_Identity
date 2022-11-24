using MVC_Database.Models;

namespace MVC_Data.ViewModels
{
    public class CreateLanguageViewModel
    {
        public LanguageViewModel NewLanguage { get; set; } = new LanguageViewModel();

        public List<Language> Languages = new List<Language>();
    }
}