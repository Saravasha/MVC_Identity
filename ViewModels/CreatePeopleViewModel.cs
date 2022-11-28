namespace MVC_Identity.Models
{
public class CreatePeopleViewModel
    {
        public PeopleViewModel NewPerson { get; set; } = new PeopleViewModel();

        public List<Person> People = new List<Person>();
        //public PeopleViewModel()
        //{
        //    NewPerson = new CreatePersonViewModel();
        //    //GetPeople();
        //}
        
        // Seedar in lite dudes
        //public List<Person> GetPeople()
        //{

            //People.Add(new Person { Id = 1, Name = "Siavash Gosheh", PhoneNumber = "xxxx-xxx666", City = new City { Id = 1 } } );
            //People.Add(new Person { Id = 2, Name = "Maxwell T Bird", PhoneNumber = "Mr. Max Tv @ Youtube", City = new City { Id = 2 } }); ;
            //People.Add(new Person { Id = 3, Name = "Nergal", PhoneNumber = "666", City = new City { Id = 3 } }); ;
            //return People;


        //}
    }
}