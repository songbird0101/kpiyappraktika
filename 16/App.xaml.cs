using System.Windows;
using EmployeeManager.Services;
using EmployeeManager.ViewModels;
using EmployeeManager.Views;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeManager
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var authService = new AuthService();
            var loginWindow = new LoginWindow(authService);
            loginWindow.Show();
        }
    }
}