using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using EmployeeManager.Models;
using EmployeeManager.Services;

namespace EmployeeManager
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private EmployeeService employeeService;
        private ObservableCollection<EmployeeModel> employees;
        private ObservableCollection<DepartmentModel> departments;
        private EmployeeModel selectedEmployee;
        private DepartmentModel selectedDepartment;

        public ObservableCollection<EmployeeModel> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DepartmentModel> Departments
        {
            get { return departments; }
            set
            {
                departments = value;
                OnPropertyChanged();
            }
        }

        public EmployeeModel SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged();
                ((RelayCommand)UpdateCommand).RaiseCanExecuteChanged();
                ((RelayCommand)DeleteCommand).RaiseCanExecuteChanged();
            }
        }

        public DepartmentModel SelectedDepartment
        {
            get { return selectedDepartment; }
            set
            {
                selectedDepartment = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ClearCommand { get; }

        public EmployeeViewModel()
        {
            employeeService = new EmployeeService();
            AddCommand = new RelayCommand(async (param) => await AddEmployee(), (param) => CanAddEmployee());
            UpdateCommand = new RelayCommand(async (param) => await UpdateEmployee(), (param) => CanUpdateEmployee());
            DeleteCommand = new RelayCommand(async (param) => await DeleteEmployee(), (param) => CanDeleteEmployee());
            ClearCommand = new RelayCommand((param) => ClearForm(), (param) => true);
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            await LoadEmployeesAsync();
            await LoadDepartmentsAsync();
        }

        public async Task LoadEmployeesAsync()
        {
            var empList = await employeeService.GetAllEmployeesAsync();
            Employees = new ObservableCollection<EmployeeModel>(empList);
        }

        public async Task LoadDepartmentsAsync()
        {
            var depList = await employeeService.GetAllDepartmentsAsync();
            Departments = new ObservableCollection<DepartmentModel>(depList);
        }

        public async Task FilterByDepartmentAsync(DepartmentModel department)
        {
            var filtered = await employeeService.FilterByDepartmentAsync(department);
            Employees = new ObservableCollection<EmployeeModel>(filtered);
        }

        private async Task AddEmployee()
        {
            if (SelectedEmployee == null)
            {
                SelectedEmployee = new EmployeeModel();
            }

            var newEmployee = new EmployeeModel
            {
                FullName = SelectedEmployee.FullName,
                Position = SelectedEmployee.Position,
                Department = SelectedEmployee.Department,
                Phone = SelectedEmployee.Phone,
                Email = SelectedEmployee.Email
            };

            await employeeService.AddEmployeeAsync(newEmployee);
            await LoadEmployeesAsync();
            ClearForm();
        }

        private async Task UpdateEmployee()
        {
            if (SelectedEmployee != null)
            {
                await employeeService.UpdateEmployeeAsync(SelectedEmployee);
                await LoadEmployeesAsync();
                ClearForm();
            }
        }

        private async Task DeleteEmployee()
        {
            if (SelectedEmployee != null)
            {
                await employeeService.DeleteEmployeeAsync(SelectedEmployee);
                await LoadEmployeesAsync();
                ClearForm();
            }
        }

        private bool CanAddEmployee()
        {
            return SelectedEmployee != null &&
                   !string.IsNullOrWhiteSpace(SelectedEmployee.FullName) &&
                   !string.IsNullOrWhiteSpace(SelectedEmployee.Position);
        }

        private bool CanUpdateEmployee()
        {
            return SelectedEmployee != null && SelectedEmployee.Id > 0;
        }

        private bool CanDeleteEmployee()
        {
            return SelectedEmployee != null && SelectedEmployee.Id > 0;
        }

        private void ClearForm()
        {
            SelectedEmployee = new EmployeeModel();
            SelectedDepartment = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}