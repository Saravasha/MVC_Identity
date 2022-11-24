using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Data.Models;
using MVC_Data.ViewModels;
using MVC_Database.Data;

namespace MVC_Database.Controllers
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
