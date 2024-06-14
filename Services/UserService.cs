using CarQuery__Test.Authentication.Services;
using CarQuery__Test.Cryptography;
using CarQuery__Test.Data;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Models.Enums;
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

        public async Task<UserAuthenticateResponse> AuthenticateAsync(UserAuthenticateRequest user)
        {

            try
            {
                User _user = _context.Users.FirstOrDefault(u => u.email == user.Email);

                if (_user == null)
                {
                    return null;
                }
                else if (user.Password.GenerateHash() != _user.password)
                {
                    return null;
                }

                string token = await TokenService.GenerateTokenAsync(_user);
                return new UserAuthenticateResponse(_user, token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static Return ValidateUser(User user)
        {

            Return ret = new Return();
            Return fCpf = ValidateCpf(user.cpf);
            Return fPass = ValidatePassword(user.password);
            Return fPhone = ValidatePhone(user.phone);

            EUserType userType = user.userType;
            ESex userSex = user.sex;

            if (user == null)
            {
                ret.Error = true;
                ret.Message = "Null User";
                return ret;
            }
            if (fCpf.Error == true)
            {
                return fCpf;
            }
            if (fPass.Error == true)
            {
                return fPass;
            }
            if (fPhone.Error == true)
            {
                return fPhone;
            }
            if (!Enum.IsDefined(typeof(EUserType), userType))
            {
                ret.Error = true;
                ret.Message = "Invalid user type.";
                return ret;
            }
            if (!Enum.IsDefined(typeof(ESex), userSex))
            {
                ret.Error = true;
                ret.Message = "Invalid user sex.";
                return ret;
            }

            ret.Success = true;
            ret.Message = "User validated";
            ret.Extra = fPhone.Extra;
            return ret;

        }

        public static Return ValidateCpf(string cpf)
        {

            Return ret = new Return();

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
            {
                ret.Error = true;
                ret.Message = "Please type 14 characters in CPF";
                return ret;
            }

            if (cpf.All(c => c == cpf[0]))
            {
                ret.Error = true;
                ret.Message = "CPF characters can't be equal";
                return ret;
            }
            ret.Success = true;
            ret.Message = "CPF validated";
            return ret;
        }

        public static Return ValidatePassword(string password)
        {

            Return ret = new Return();

            if (password.Length < 7)
            {
                ret.Error = true;
                ret.Message = "Password requires at least 8 characters.";
                return ret;
            }

            if (!password.Any(char.IsUpper))
            {
                ret.Error = true;
                ret.Message = "Password requires at least 1 uppercase.";
                return ret;
            }

            if (!password.Any(char.IsLower))
            {
                ret.Error = true;
                ret.Message = "Password requires at least 1 lowercase.";
                return ret;
            }

            if (!password.Any(char.IsDigit))
            {
                ret.Error = true;
                ret.Message = "Password requires at least 1 number.";
                return ret;
            }

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                ret.Error = true;
                ret.Message = "Password requires at least 1 special character.";
                return ret;
            }

            ret.Success = true;
            ret.Message = "Password validated";
            return ret;
        }

        public static Return ValidatePhone(string phone)
        {
            var ret = new Return();

            phone = new string(phone.Where(char.IsDigit).ToArray());

            if (phone.Length < 10 || phone.Length > 11)
            {
                ret.Error = true;
                ret.Message = "Phone number must have 10 or 11 digits.";
                return ret;
            }

            if (phone[0] == '0')
            {
                ret.Error = true;
                ret.Message = "Phone number can't start with '0'.";
                return ret;
            }

            string pattern = @"^(\d{2})(\d{8,9})$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, pattern))
            {
                ret.Error = true;
                ret.Message = "Invalid phone number format.";
                return ret;
            }

            ret.Success = true;
            ret.Message = "Phone validated";
            ret.Extra = phone;
            return ret;
        }

        public async Task<Return> CreateUserAsync(User user)
        {
            try
            {

                Return ret = ValidateUser(user);

                if (ret.Success == true)
                {
                    if (ret.Extra != null)
                    {
                        user.phone = ret.Extra;
                    }

                    user.password = user.password.GenerateHash();

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    ret.Success = true;
                    ret.Message = "User created";
                    return ret;
                }
                else
                {
                    return ret;
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

        public async Task<Return> UpdateUserAsync(int id, User user)
        {
            Return ret = ValidateUser(user);
            var existingUser = await _context.Users.FindAsync(id);

            if (ret.Error == true)
            {
                return ret;
            }
            else if (existingUser == null)
            {
                ret.Error = true;
                ret.Message = "User not found.";
                return ret;
            }
            else
            {
                existingUser.nameUser = user.nameUser;
                existingUser.cpf = user.cpf;
                existingUser.password = user.password.GenerateHash();
                existingUser.email = user.email;
                existingUser.phone = user.phone;
                existingUser.birth = user.birth;
                existingUser.sex = user.sex;
                existingUser.userType = user.userType;

                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();

                ret.Success = true;
                ret.Message = "User " + user.nameUser + " updated successfully.";
                return ret;
            }
        }
    }
}
