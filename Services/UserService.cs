using CarQuery__Test.Data;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CarQuery__Test.Services
{
    public class UserService : BaseRepository, IUserService
    {

        public UserService(AppDbContext context) : base(context)
        {
        }

        public static User ValidateUser(User user)
        {

            if (user != null && !string.IsNullOrEmpty(user.nameUser) && user.sex != null && !string.IsNullOrEmpty(user.cpf) && user.birth != null
                && !string.IsNullOrEmpty(user.password) && !string.IsNullOrEmpty(user.email) && !string.IsNullOrEmpty(user.phone)
                && user.userType != 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<User> CreateUserAsync(User user)
        {
            try
            {

                var ret = ValidateUser(user);

                if (ret != null)
                {
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    return user;
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

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var userToDelete = await _context.Users.FindAsync(id);
                if (userToDelete == null)
                {
                    return false;
                }

                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir a pessoa.", ex);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            var ret = ValidateUser(user);
            var existingUser = await _context.Users.FindAsync(id);

            if (ret == null)
            {
                return null;
            }
            else if (existingUser == null)
            {
                return null;
            }
            else
            {
                existingUser.nameUser = user.nameUser;
                existingUser.cpf = user.cpf;
                existingUser.password = user.password;
                existingUser.email = user.email;
                existingUser.phone = user.phone;
                existingUser.birth = user.birth;
                existingUser.sex = user.sex;
                existingUser.userType = user.userType;

                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();

                return user;
            }
        }
    }
}
