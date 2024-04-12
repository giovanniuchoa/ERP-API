using CarQuery__Test.Domain.Models;

namespace CarQuery__Test.Domain.Services
{
    public interface IPersonService
    { 
        IEnumerable<Person> GetAllPersons();
        IEnumerable<Person> GetPersonById(int id);
        bool CreatePerson(Person person);
        IEnumerable<Person> UpdatePerson(int id, Person person);
        bool DeletePerson(int id);

    }
}
