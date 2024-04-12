using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarQuery__Test.Controllers
{

    [Route("Person")]
    public class PersonController : ControllerBase 
    {

        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet] //Get all persons
        public IEnumerable<Person> GetAllPersons()
        {
            var persons = _personService.GetAllPersons();
            return persons;
        }

        [HttpGet("{id}")] //Get person by id
        public IEnumerable<Person> GetPerson(int id)
        {
            var person = _personService.GetPersonById(id);
            return person;
        }

        [HttpPost] //Create a new person
        public bool CreatePerson([FromBody] Person person)
        {
            bool result = _personService.CreatePerson(person);
            return result;
        }

        [HttpPut("{id}")] //Update a person
        public IEnumerable<Person> UpdatePerson(int id, [FromBody] Person person)
        {
            var newPerson = _personService.UpdatePerson(id, person);
            return newPerson;
        }

        [HttpDelete("{id}")] //Delete a person
        public bool DeletePerson(int id)
        {
            bool result = _personService.DeletePerson(id);
            return result;
        }
    }

    
}
