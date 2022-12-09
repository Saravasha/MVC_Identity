using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Identity.Data;
using MVC_Identity.Models;

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
            var people = _context.People.Find(id);
            return (IActionResult) people;
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
