using CarQuery__Test.Domain.Models;

namespace CarQuery__Test.Domain.Services
{
    public interface IUserService
    { 
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id); 
        Task<Return> CreateUserAsync(User user); 
        Task<Return> UpdateUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);
        Task<UserAuthenticateResponse> AuthenticateAsync(UserAuthenticateRequest user);

    }
}      