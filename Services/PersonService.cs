using CarQuery__Test.Data;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;

namespace CarQuery__Test.Services
{
    public class PersonService : BaseRepository, IPersonService
    {

        public PersonService(AppDbContext context) : base(context)
        {
        }

        public bool CreatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public bool DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> UpdatePerson(int id, Person person)
        {
            throw new NotImplementedException();
        }
    }
}
