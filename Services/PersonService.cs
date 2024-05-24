using CarQuery__Test.Data;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CarQuery__Test.Services
{
    public class PersonService : BaseRepository, IPersonService
    {

        public PersonService(AppDbContext context) : base(context)
        {
        }

        public static Person ValidatePerson(Person person)
        {

            if (person != null && !string.IsNullOrEmpty(person.Name) && person.Sex != null && !string.IsNullOrEmpty(person.Cpf) && person.Birth != null)
            {
                return person;
            }
            else
            {
                return null;
            }
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            try
            {

                var ret = ValidatePerson(person);

                if (ret != null)
                {
                    _context.Persons.Add(person);
                    await _context.SaveChangesAsync();
                    return person;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            try
            {
                var personToDelete = await _context.Persons.FindAsync(id);
                if (personToDelete == null)
                {
                    return false;
                }

                _context.Persons.Remove(personToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir a pessoa.", ex);
            }
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<Person> UpdatePersonAsync(int id, Person person)
        {
            var ret = ValidatePerson(person);
            var existingPerson = await _context.Persons.FindAsync(id);

            if (ret == null)
            {
                return null;
            }
            else if (existingPerson == null)
            {
                return null;
            }
            else
            {
                existingPerson.Name = person.Name;
                existingPerson.Birth = person.Birth;
                existingPerson.Sex = person.Sex;
                existingPerson.Cpf = person.Cpf;

                _context.Persons.Update(existingPerson);
                await _context.SaveChangesAsync();

                return person;
            }
        }
    }
}
