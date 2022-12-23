
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Identity.Data;
using MVC_Identity.Models;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace MVC_Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        readonly MVC_DbContext _context;
        public ReactController(MVC_DbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public List<City> GetCities()
        //{
        //    List<City> cities = new List<City>();
        //    cities = _context.Cities.ToList();
        //    return cities;
        //}

        [HttpGet("create")]
        public SelectList GetCities(int id)
        {
            var cityList = new SelectList(_context.Cities, "Id", "Name");
            return cityList;
        }

        //[HttpGet]
        //public List<Person> Getppl()
        //{
        //    List<Person> people = new List<Person>();
        //    people = _context.People.Include(c => c.City).ToList();
        //    return people;
        //}

        //[HttpGet("personcity")]
        //public List<Person> GetCityPeople(int id)
        //{
        //    var people = new List<Person>();

        //    people = _context.People.Include(c => c.City).ToList();
        //    return people;
        //}

        [HttpGet("person")]
        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            people = _context.People.Include(c => c.City).ThenInclude(C => C.Country).ToList();
            return people;
        }

        //[HttpGet("persondetails")]
        //public IActionResult GetPeople(int id)
        //{
        //    var person = _context.People.Find(id);
        //    return person as IActionResult;
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _context.People.Find(id);
            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
                return StatusCode(200);
            }
            return StatusCode(404);
        }

        [HttpPost("create")]
        public IActionResult Create(JsonObject person)
        {
            string jsonPerson = person.ToString();
            Person personToCreate = JsonConvert.DeserializeObject<Person>(jsonPerson);

            if (personToCreate != null)
            {
                _context.People.Add(personToCreate);
                _context.SaveChanges();

                return StatusCode(200);
            }
            return StatusCode(404);
        }

    }
}
