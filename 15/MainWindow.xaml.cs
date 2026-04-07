using System.Windows;
using System.Windows.Controls;

namespace EmployeeManager
{
    public partial class MainWindow : Window
    {
        private EmployeeViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new EmployeeViewModel();
            DataContext = viewModel;
        }

        private async void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pbLoading.Visibility = Visibility.Visible;
            await viewModel.FilterByDepartmentAsync(cbDepartment.SelectedItem as DepartmentModel);
            pbLoading.Visibility = Visibility.Collapsed;
        }
    }
}