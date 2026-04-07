using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManager.Models;

namespace EmployeeManager.Services
{
    public class EmployeeService
    {
        private List<EmployeeModel> employees;
        private List<DepartmentModel> departments;

        public EmployeeService()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            departments = new List<DepartmentModel>
            {
                new DepartmentModel { Id = 1, Name = "Отдел продаж" },
                new DepartmentModel { Id = 2, Name = "IT отдел" },
                new DepartmentModel { Id = 3, Name = "Дизайн отдел" },
                new DepartmentModel { Id = 4, Name = "Аналитический отдел" }
            };

            employees = new List<EmployeeModel>
            {
                new EmployeeModel { Id = 1, FullName = "Иванов Иван Иванович", Position = "Менеджер", Department = departments[0], Phone = "+7 999 123-45-67", Email = "ivanov@mail.ru" },
                new EmployeeModel { Id = 2, FullName = "Петров Петр Петрович", Position = "Разработчик", Department = departments[1], Phone = "+7 999 234-56-78", Email = "petrov@mail.ru" },
                new EmployeeModel { Id = 3, FullName = "Сидорова Анна Сергеевна", Position = "Дизайнер", Department = departments[2], Phone = "+7 999 345-67-89", Email = "sidorova@mail.ru" },
                new EmployeeModel { Id = 4, FullName = "Кузнецов Дмитрий Алексеевич", Position = "Разработчик", Department = departments[1], Phone = "+7 999 456-78-90", Email = "kuznetsov@mail.ru" },
                new EmployeeModel { Id = 5, FullName = "Смирнова Елена Владимировна", Position = "Менеджер", Department = departments[0], Phone = "+7 999 567-89-01", Email = "smirnova@mail.ru" },
                new EmployeeModel { Id = 6, FullName = "Морозов Андрей Викторович", Position = "Аналитик", Department = departments[3], Phone = "+7 999 678-90-12", Email = "morozov@mail.ru" }
            };
        }

        public async Task<List<EmployeeModel>> GetAllEmployeesAsync()
        {
            return await Task.Run(() => employees);
        }

        public async Task<List<DepartmentModel>> GetAllDepartmentsAsync()
        {
            return await Task.Run(() => departments);
        }

        public async Task<List<EmployeeModel>> FilterByDepartmentAsync(DepartmentModel department)
        {
            return await Task.Run(() =>
            {
                if (department == null)
                    return employees;
                return employees.FindAll(e => e.Department?.Id == department.Id);
            });
        }

        public async Task<bool> AddEmployeeAsync(EmployeeModel employee)
        {
            return await Task.Run(() =>
            {
                if (employee == null) return false;
                employee.Id = employees.Count + 1;
                employees.Add(employee);
                return true;
            });
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeModel employee)
        {
            return await Task.Run(() =>
            {
                if (employee == null) return false;
                var index = employees.FindIndex(e => e.Id == employee.Id);
                if (index != -1)
                {
                    employees[index] = employee;
                    return true;
                }
                return false;
            });
        }

        public async Task<bool> DeleteEmployeeAsync(EmployeeModel employee)
        {
            return await Task.Run(() =>
            {
                if (employee == null) return false;
                return employees.Remove(employee);
            });
        }
    }
}