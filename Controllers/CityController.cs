using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Identity.Data;
using MVC_Identity.Models;

namespace MVC_Identity.Controllers
{
    public class CityController : Controller
    {

        //private static CreateCityViewModel cityViewModel = new CreateCityViewModel();
        readonly MVC_DbContext _context; // creates a readonly of DbContext

        public CityController(MVC_DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {


            var cityList = _context.Cities.Include(c => c.Country).ToList();

            return View(cityList);
        }

        public IActionResult AddCity()
        {
            ViewBag.CountryNames = new SelectList(_context.Countries, "Id", "Name");


            return View();

        }

        [HttpPost]
        public IActionResult AddCity(CreateCityViewModel c)
        {

            if (ModelState.IsValid)
            {

                _context.Add(new City()

                {
                    Name = c.NewCity.Name,
                    CountryId = c.NewCity.CountryId,
                });


                _context.SaveChanges();

                ViewBag.Statement = $"{_context.Cities} has been added to the table!";
            }
            else
            {
                ViewBag.CountryNames = new SelectList(_context.Countries, "Id", "Name");
                ViewBag.Statement = "Please fill in the form above!";
                return View("AddCity", c);
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id, string name)
        {
            var city = _context.Cities.FirstOrDefault(x => x.Id == id);
            if (city != null)
            {
                _context.Cities.Remove(city);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}
