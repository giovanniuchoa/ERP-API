using CarQuery__Test.Domain.Models;

namespace CarQuery__Test.Domain.Services
{
    public interface IUserService
    { 
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id); 
        Task<User> CreateUserAsync(User user); 
        Task<User> UpdateUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);

    }
}      