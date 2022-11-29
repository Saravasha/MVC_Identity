using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using MVC_Identity.Data;

namespace MVC_Identity.Models

{
    [Authorize(Roles = "User, Admin")]
    public class LanguageController : Controller
    {

        private static CreateLanguageViewModel languageViewModel = new CreateLanguageViewModel();
        readonly MVC_DbContext _context;
        public LanguageController(MVC_DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var languageList = _context.Languages.ToList();

            return View(languageList);
        }

        public IActionResult AddLanguage()
        {
           
            return View();

        }

        [HttpPost]
        public IActionResult AddLanguage(CreateLanguageViewModel l)
        {
            if (ModelState.IsValid)
            {

                _context.Add(new Language()
                {
                    Name = l.NewLanguage.Name
                });

                _context.SaveChanges();
            }
            else
            {
                ViewBag.Statement = "Please fill in the form above!";
                return View("AddLanguage", l);

            }
            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id, string name)
        {
            var lang = _context.Languages.FirstOrDefault(x => x.Id == id);
            if (lang != null)
            {
                _context.Languages.Remove(lang);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}
