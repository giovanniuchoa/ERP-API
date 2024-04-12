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
            try
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool DeletePerson(int id)
        {
            try
            {
                var existingPerson = _context.Persons.Find(id);
                _context.Persons.Remove(existingPerson);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
            
        }

        public IEnumerable<Person> GetPersonById(int id)
        {
            var person = _context.Persons.Find(id);
            yield return person;
        } 

        public IEnumerable<Person> UpdatePerson(int id, Person person)
        {
            var existingPerson = _context.Persons.Find(id);

            existingPerson.Name = person.Name;
            existingPerson.Birth = person.Birth;
            existingPerson.Sex = person.Sex;
            existingPerson.Cpf = person.Cpf;

            _context.SaveChanges();

            yield return person;
        }
    }
}
