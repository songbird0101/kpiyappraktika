using System.Windows;

namespace EmployeeManager
{
    public partial class EmployeeWindow : Window
    {
        public Employee NewEmployee { get; private set; }
        private bool isEditMode = false;

        public EmployeeWindow(Employee employee = null)
        {
            InitializeComponent();
            if (employee != null)
            {
                isEditMode = true;
                tbFullName.Text = employee.FullName;
                cbPosition.Text = employee.Position;
                tbDepartment.Text = employee.Department;
                tbPhone.Text = employee.Phone;
                tbEmail.Text = employee.Email;
                Title = "Редактирование сотрудника";
            }
            else
            {
                Title = "Добавление сотрудника";
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                NewEmployee = new Employee
                {
                    FullName = tbFullName.Text,
                    Position = cbPosition.Text,
                    Department = tbDepartment.Text,
                    Phone = tbPhone.Text,
                    Email = tbEmail.Text
                };
                DialogResult = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
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
    }
}