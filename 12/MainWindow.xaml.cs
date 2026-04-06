using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeManager
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Employee> allEmployees;
        private ObservableCollection<Employee> filteredEmployees;

        public MainWindow()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            allEmployees = new ObservableCollection<Employee>
            {
                new Employee { FullName = "Иванов Иван Иванович", Position = "Менеджер", Department = "Отдел продаж", Phone = "+7 999 123-45-67", Email = "ivanov@mail.ru" },
                new Employee { FullName = "Петров Петр Петрович", Position = "Разработчик", Department = "IT отдел", Phone = "+7 999 234-56-78", Email = "petrov@mail.ru" },
                new Employee { FullName = "Сидорова Анна Сергеевна", Position = "Дизайнер", Department = "Дизайн отдел", Phone = "+7 999 345-67-89", Email = "sidorova@mail.ru" },
                new Employee { FullName = "Кузнецов Дмитрий Алексеевич", Position = "Разработчик", Department = "IT отдел", Phone = "+7 999 456-78-90", Email = "kuznetsov@mail.ru" },
                new Employee { FullName = "Смирнова Елена Владимировна", Position = "Менеджер", Department = "Отдел продаж", Phone = "+7 999 567-89-01", Email = "smirnova@mail.ru" },
                new Employee { FullName = "Морозов Андрей Викторович", Position = "Аналитик", Department = "Аналитический отдел", Phone = "+7 999 678-90-12", Email = "morozov@mail.ru" }
            };
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string selectedPosition = GetSelectedPosition();

            if (selectedPosition == "Все")
            {
                filteredEmployees = new ObservableCollection<Employee>(allEmployees);
            }
            else
            {
                filteredEmployees = new ObservableCollection<Employee>(
                    allEmployees.Where(e => e.Position == selectedPosition));
            }
            lvEmployees.ItemsSource = filteredEmployees;
        }

        private string GetSelectedPosition()
        {
            if (rbAll.IsChecked == true) return "Все";
            if (rbManager.IsChecked == true) return "Менеджер";
            if (rbDeveloper.IsChecked == true) return "Разработчик";
            if (rbDesigner.IsChecked == true) return "Дизайнер";
            if (rbAnalyst.IsChecked == true) return "Аналитик";
            return "Все";
        }

        private void Filter_Changed(object sender, RoutedEventArgs e)
        {
            ApplyFilter();
            ClearForm();
        }

        private void lvEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvEmployees.SelectedItem != null)
            {
                Employee selected = (Employee)lvEmployees.SelectedItem;
                tbFullName.Text = selected.FullName;
                cbPosition.Text = selected.Position;
                tbDepartment.Text = selected.Department;
                tbPhone.Text = selected.Phone;
                tbEmail.Text = selected.Email;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                Employee newEmployee = new Employee
                {
                    FullName = tbFullName.Text,
                    Position = cbPosition.Text,
                    Department = tbDepartment.Text,
                    Phone = tbPhone.Text,
                    Email = tbEmail.Text
                };
                allEmployees.Add(newEmployee);
                ApplyFilter();
                ClearForm();
                MessageBox.Show("Сотрудник добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployees.SelectedItem != null && ValidateForm())
            {
                Employee selected = (Employee)lvEmployees.SelectedItem;
                selected.FullName = tbFullName.Text;
                selected.Position = cbPosition.Text;
                selected.Department = tbDepartment.Text;
                selected.Phone = tbPhone.Text;
                selected.Email = tbEmail.Text;
                lvEmployees.Items.Refresh();
                ApplyFilter();
                ClearForm();
                MessageBox.Show("Сотрудник обновлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployees.SelectedItem != null)
            {
                Employee selected = (Employee)lvEmployees.SelectedItem;
                if (MessageBox.Show($"Удалить сотрудника {selected.FullName}?", "Подтверждение",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    allEmployees.Remove(selected);
                    ApplyFilter();
                    ClearForm();
                    MessageBox.Show("Сотрудник удален!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(tbFullName.Text))
            {
                MessageBox.Show("Введите ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbPosition.Text))
            {
                MessageBox.Show("Выберите должность", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbDepartment.Text))
            {
                MessageBox.Show("Введите отдел", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Введите телефон", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Введите Email", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            tbFullName.Text = "";
            cbPosition.SelectedIndex = -1;
            tbDepartment.Text = "";
            tbPhone.Text = "";
            tbEmail.Text = "";
            lvEmployees.SelectedItem = null;
        }
    }

    public class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}