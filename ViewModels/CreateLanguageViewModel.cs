namespace MVC_Identity.Models
{
    public class CreateLanguageViewModel
    {
        public LanguageViewModel NewLanguage { get; set; } = new LanguageViewModel();

        public List<Language> Languages = new List<Language>();
    }
}