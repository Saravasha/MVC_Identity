using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Identity.Data;
using MVC_Identity.Models;
using Newtonsoft.Json;

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
        //public List<Person> GetCities()
        //{
        //    List<City> cities = new List<City>();
        //    cities = _context.Cities.ToList();
        //    return cities;
        //}

        public SelectList GetCities()
        {
            var cityList = new SelectList(_context.Cities, "Id", "Name");
            return cityList;
        }

        [HttpGet]
        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            people = _context.People.ToList();
            return people;
        }

        [HttpGet("{id}")]
        public IActionResult GetPeople(int id)
        {
            var person = _context.People.Find(id);
            return (IActionResult) person;
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
    }
}
