using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace EmployeeManager
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Employee> employees;
        private EmployeeViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            LoadEmployees();
            viewModel = new EmployeeViewModel(employees);
            DataContext = viewModel;
        }

        private void LoadEmployees()
        {
            employees = new ObservableCollection<Employee>
            {
                new Employee { FullName = "Иванов Иван Иванович", Position = "Менеджер", Department = "Отдел продаж", Phone = "+7 999 123-45-67", Email = "ivanov@mail.ru" },
                new Employee { FullName = "Петров Петр Петрович", Position = "Разработчик", Department = "IT отдел", Phone = "+7 999 234-56-78", Email = "petrov@mail.ru" },
                new Employee { FullName = "Сидорова Анна Сергеевна", Position = "Дизайнер", Department = "Дизайн отдел", Phone = "+7 999 345-67-89", Email = "sidorova@mail.ru" },
                new Employee { FullName = "Кузнецов Дмитрий Алексеевич", Position = "Разработчик", Department = "IT отдел", Phone = "+7 999 456-78-90", Email = "kuznetsov@mail.ru" },
                new Employee { FullName = "Смирнова Елена Владимировна", Position = "Менеджер", Department = "Отдел продаж", Phone = "+7 999 567-89-01", Email = "smirnova@mail.ru" }
            };
            lvEmployees.ItemsSource = employees;
        }

        private void lvEmployees_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lvEmployees.SelectedItem != null)
            {
                viewModel.SelectedEmployee = (Employee)lvEmployees.SelectedItem;
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            lvEmployees.Items.Refresh();
            tbStatus.Text = "Список обновлен";
        }

        private void ReportByPosition_Click(object sender, RoutedEventArgs e)
        {
            string report = "Отчёт по должностям:\n";
            var groups = new System.Collections.Generic.Dictionary<string, int>();
            foreach (var emp in employees)
            {
                if (groups.ContainsKey(emp.Position))
                    groups[emp.Position]++;
                else
                    groups[emp.Position] = 1;
            }
            foreach (var g in groups)
            {
                report += $"{g.Key}: {g.Value} чел.\n";
            }
            MessageBox.Show(report, "Отчёт", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ReportByDepartment_Click(object sender, RoutedEventArgs e)
        {
            string report = "Отчёт по отделам:\n";
            var groups = new System.Collections.Generic.Dictionary<string, int>();
            foreach (var emp in employees)
            {
                if (groups.ContainsKey(emp.Department))
                    groups[emp.Department]++;
                else
                    groups[emp.Department] = 1;
            }
            foreach (var g in groups)
            {
                report += $"{g.Key}: {g.Value} чел.\n";
            }
            MessageBox.Show(report, "Отчёт", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ReportFullList_Click(object sender, RoutedEventArgs e)
        {
            string report = "Полный список сотрудников:\n\n";
            foreach (var emp in employees)
            {
                report += $"{emp.FullName} | {emp.Position} | {emp.Department}\n";
            }
            MessageBox.Show(report, "Отчёт", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Настройки приложения", "Настройки", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Автоматизация учета сотрудников\nВерсия 1.0", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class EmployeeViewModel
    {
        private ObservableCollection<Employee> employees;
        public Employee SelectedEmployee { get; set; }

        public ICommand AddEmployeeCommand { get; }
        public ICommand EditEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }

        public EmployeeViewModel(ObservableCollection<Employee> employees)
        {
            this.employees = employees;
            AddEmployeeCommand = new RelayCommand(AddEmployee);
            EditEmployeeCommand = new RelayCommand(EditEmployee);
            DeleteEmployeeCommand = new RelayCommand(DeleteEmployee);
        }

        private void AddEmployee()
        {
            EmployeeWindow window = new EmployeeWindow();
            if (window.ShowDialog() == true)
            {
                employees.Add(window.NewEmployee);
                MessageBox.Show("Сотрудник добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditEmployee()
        {
            if (SelectedEmployee == null)
            {
                MessageBox.Show("Выберите сотрудника для редактирования", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            EmployeeWindow window = new EmployeeWindow(SelectedEmployee);
            if (window.ShowDialog() == true)
            {
                SelectedEmployee.FullName = window.NewEmployee.FullName;
                SelectedEmployee.Position = window.NewEmployee.Position;
                SelectedEmployee.Department = window.NewEmployee.Department;
                SelectedEmployee.Phone = window.NewEmployee.Phone;
                SelectedEmployee.Email = window.NewEmployee.Email;
                MessageBox.Show("Сотрудник обновлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteEmployee()
        {
            if (SelectedEmployee == null)
            {
                MessageBox.Show("Выберите сотрудника для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (MessageBox.Show($"Удалить сотрудника {SelectedEmployee.FullName}?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                employees.Remove(SelectedEmployee);
                MessageBox.Show("Сотрудник удален!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }

    public class RelayCommand : ICommand
    {
        private Action execute;
        private Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}