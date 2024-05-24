using CarQuery__Test.Domain.Models;

namespace CarQuery__Test.Domain.Services
{
    public interface IPersonService
    { 
        Task<IEnumerable<Person>> GetAllPersonsAsync();
        Task<Person> GetPersonByIdAsync(int id); 
        Task<Person> CreatePersonAsync(Person person); 
        Task<Person> UpdatePersonAsync(int id, Person person);
        Task<bool> DeletePersonAsync(int id);

    }
}      