using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeManager.Models;

namespace EmployeeManager.Services
{
    public class DataService
    {
        private readonly string employeesFile = "employees.json";
        private readonly string usersFile = "users.json";

        public async Task SaveEmployeesAsync(List<EmployeeModel> employees)
        {
            var json = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(employeesFile, json);
        }

        public async Task<List<EmployeeModel>> LoadEmployeesAsync()
        {
            if (!File.Exists(employeesFile))
                return new List<EmployeeModel>();
            var json = await File.ReadAllTextAsync(employeesFile);
            return JsonSerializer.Deserialize<List<EmployeeModel>>(json) ?? new List<EmployeeModel>();
        }

        public async Task SaveUsersAsync(List<UserModel> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(usersFile, json);
        }

        public async Task<List<UserModel>> LoadUsersAsync()
        {
            if (!File.Exists(usersFile))
                return new List<UserModel>();
            var json = await File.ReadAllTextAsync(usersFile);
            return JsonSerializer.Deserialize<List<UserModel>>(json) ?? new List<UserModel>();
        }
    }
}