using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Identity.Models;

namespace MVC_Identity.Data
{
    [Authorize(Roles = "User, Admin")]
    public class LanguagePersonController : Controller
    {
        private static CreatePeopleViewModel peopleViewModel = new CreatePeopleViewModel();
        readonly MVC_DbContext _context; // creates a readonly of DbContext

        public LanguagePersonController(MVC_DbContext context)
        {
            _context = context;
        }

        // Skicka DropdownList PersonItem från View till Controller som sedan uppdaterar språken som inte finns tillgängliga hos Personen. Controller gör redan kända språk till disabled och sedan passeras språklistan till controllern igen.

        public IActionResult AddLanguagePerson()
        {
            ViewBag.PeopleNames = new SelectList(_context.People, "Id", "Name");
            ViewBag.LanguageNames = new SelectList(_context.Languages, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult AddLanguagePerson(string personId, List<string> languages)
        {

            var person = _context.People.FirstOrDefault(x => x.Id == int.Parse(personId));
            var langsToString = "";
            List<string> langList = new List<string>();
            foreach (var lang in languages)
            {
                var language = _context.Languages.FirstOrDefault(x => x.Id.Equals(int.Parse(lang)));

                langList.Add(language.Name);
                langsToString = string.Join(", ", langList);

                try
                {
                    person.Languages.Add(language);

                    _context.SaveChanges();
                }
                catch (DbUpdateException e)
                {

                    ViewBag.Message = $"{e.Message} something went wrong";
                }
            }
            TempData["Message"] = $"Added {langsToString} to {person.Name}";
            return RedirectToAction("AddLanguagePerson");

        }


    }
}
