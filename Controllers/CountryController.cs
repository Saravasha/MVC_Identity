using Microsoft.AspNetCore.Mvc;
using MVC_Identity.Data;
using MVC_Identity.Models;

namespace MVC_Identity.Controllers
{
    public class CountryController : Controller
    {

        //private static CreateCountryViewModel cityViewModel = new CreateCountryViewModel();
        readonly MVC_DbContext _context; // creates a readonly of DbContext

        public CountryController(MVC_DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {


            var countryList = _context.Countries.ToList();

            return View(countryList);
        }

        public IActionResult AddCountry()
        {
            

            return View();

        }

        [HttpPost]
        public IActionResult AddCountry(CreateCountryViewModel C)
        {

            if (ModelState.IsValid)
            {

                _context.Add(new Country()

                {
                    Name = C.NewCountry.Name,

                });


                _context.SaveChanges();

                ViewBag.Statement = $"{C.NewCountry.Name} has been added to the table!";
            }
            else
            {
                ViewBag.Statement = "Please fill in the form above!";
                return View("AddCountry", C);
            }
            return RedirectToAction("Index");
        }

       
        public IActionResult Delete(int id, string name)
        {
            var country = _context.Countries.FirstOrDefault(x => x.Id == id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}
