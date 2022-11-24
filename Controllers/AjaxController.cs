using Microsoft.AspNetCore.Mvc;
using MVC_Data.ViewModels;
using MVC_Data.Models;


namespace MVC_Data.Controllers
{
    public class AjaxController : Controller
    {
        public static CreatePeopleViewModel person = new CreatePeopleViewModel();


        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult GetPeople() { 
            
            return PartialView("_PersonPartial", person); 
        }

        [HttpPost]
        public IActionResult GetPeople(int id)
        {
            var filteredData = person.People.Where(x => x.Id == id).ToList();


            CreatePeopleViewModel filteredModel = new CreatePeopleViewModel();


            filteredModel.People = filteredData;

            if (filteredModel.People.Count == 0)
            {
                return PartialView("_PersonPartial");
            }

            return PartialView("_PersonPartial", filteredModel);

        }

        [HttpPost]
        public IActionResult AnnihilatePerson(int id)
        {
            static string OrdinalSuffixGetter(int Id)
            {
                string number = Id.ToString();
                if (number.EndsWith("11")) return "th";
                if (number.EndsWith("12")) return "th";
                if (number.EndsWith("13")) return "th";
                if (number.EndsWith("1")) return "st";
                if (number.EndsWith("2")) return "nd";
                if (number.EndsWith("3")) return "rd";
                return "th";
            }
            if (!id.Equals(null))
            {
                try
                {
                    Person? p = person.People.FirstOrDefault(p => p.Id == id);
                    if(p!=null)
                    {
                    person.People.Remove(p);   
                    ViewBag.Statement = $" OMG! They killed {p.Name} the {p.Id}{OrdinalSuffixGetter(p.Id)}! You bastards!";
                    } else if (p!=null)
                    {
                        ViewBag.Statement = "$Stop, he's already dead!!";
                    }

                }
                catch (ArgumentOutOfRangeException aa)
                {
                    ViewBag.Statement = aa.Message;
                }
            }
            else
            {
                ViewBag.Statement = "Unable to comply!";
            }

            return PartialView("_PersonPartial", person);
        }
    }

}
