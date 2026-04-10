using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EmployeeManager.Models;

namespace EmployeeManager.Services
{
    public class AuthService
    {
        private readonly DataService dataService;
        private List<UserModel> users;
        private UserModel currentUser;

        public UserModel CurrentUser => currentUser;

        public AuthService()
        {
            dataService = new DataService();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToHexString(hash);
            }
        }

        public async Task<bool> RegisterAsync(string username, string password, string department)
        {
            users = await dataService.LoadUsersAsync();

            if (users.Any(u => u.Username == username))
                return false;

            var newUser = new UserModel
            {
                Id = users.Count + 1,
                Username = username,
                PasswordHash = HashPassword(password),
                Department = department,
                IsLoggedIn = false
            };

            users.Add(newUser);
            await dataService.SaveUsersAsync(users);
            return true;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            users = await dataService.LoadUsersAsync();
            var hash = HashPassword(password);
            var user = users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hash);

            if (user != null)
            {
                currentUser = user;
                user.IsLoggedIn = true;
                await dataService.SaveUsersAsync(users);
                return true;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            if (currentUser != null)
            {
                currentUser.IsLoggedIn = false;
                await dataService.SaveUsersAsync(users);
                currentUser = null;
            }
        }
    }
}