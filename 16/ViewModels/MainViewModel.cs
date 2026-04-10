using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using EmployeeManager.Models;
using EmployeeManager.Services;

namespace EmployeeManager.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DataService dataService;
        private readonly AuthService authService;
        private readonly ChatService chatService;
        private readonly NotificationService notificationService;

        private ObservableCollection<EmployeeModel> employees;
        private EmployeeModel selectedEmployee;

        public ObservableCollection<EmployeeModel> Employees
        {
            get { return employees; }
            set { employees = value; OnPropertyChanged(); }
        }

        public EmployeeModel SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; OnPropertyChanged(); }
        }

        public string CurrentUser => authService.CurrentUser?.Username ?? "Гость";
        public string CurrentDepartment => authService.CurrentUser?.Department ?? "Неизвестно";

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand OpenChatCommand { get; }
        public ICommand LogoutCommand { get; }

        public MainViewModel(AuthService authService)
        {
            this.authService = authService;
            dataService = new DataService();
            chatService = new ChatService();
            notificationService = new NotificationService();

            AddCommand = new RelayCommand(async _ => await AddEmployee());
            UpdateCommand = new RelayCommand(async _ => await UpdateEmployee(), _ => SelectedEmployee != null);
            DeleteCommand = new RelayCommand(async _ => await DeleteEmployee(), _ => SelectedEmployee != null);
            ClearCommand = new RelayCommand(_ => ClearForm());
            OpenChatCommand = new RelayCommand(_ => OpenChat());
            LogoutCommand = new RelayCommand(async _ => await Logout());

            LoadDataAsync();
            StartChatServer();
            StartNotifications();
        }

        private async void LoadDataAsync()
        {
            await LoadEmployeesAsync();
        }

        private async Task LoadEmployeesAsync()
        {
            var list = await dataService.LoadEmployeesAsync();
            Employees = new ObservableCollection<EmployeeModel>(list);
        }

        private async Task AddEmployee()
        {
            if (SelectedEmployee == null) SelectedEmployee = new EmployeeModel();
            var list = Employees.ToList();
            SelectedEmployee.Id = list.Count + 1;
            list.Add(SelectedEmployee);
            await dataService.SaveEmployeesAsync(list);
            await LoadEmployeesAsync();

            // Отправляем уведомление
            notificationService.SendNotification(new ChatMessage
            {
                Sender = CurrentUser,
                Department = CurrentDepartment,
                Message = $"Добавлен сотрудник {SelectedEmployee.FullName}",
                Timestamp = DateTime.Now
            });
            ClearForm();
        }

        private async Task UpdateEmployee()
        {
            if (SelectedEmployee != null)
            {
                var list = Employees.ToList();
                var index = list.FindIndex(e => e.Id == SelectedEmployee.Id);
                if (index >= 0)
                {
                    list[index] = SelectedEmployee;
                    await dataService.SaveEmployeesAsync(list);
                    await LoadEmployeesAsync();

                    notificationService.SendNotification(new ChatMessage
                    {
                        Sender = CurrentUser,
                        Department = CurrentDepartment,
                        Message = $"Обновлён сотрудник {SelectedEmployee.FullName}",
                        Timestamp = DateTime.Now
                    });
                }
            }
        }

        private async Task DeleteEmployee()
        {
            if (SelectedEmployee != null)
            {
                var list = Employees.ToList();
                list.RemoveAll(e => e.Id == SelectedEmployee.Id);
                await dataService.SaveEmployeesAsync(list);
                await LoadEmployeesAsync();

                notificationService.SendNotification(new ChatMessage
                {
                    Sender = CurrentUser,
                    Department = CurrentDepartment,
                    Message = $"Удалён сотрудник {SelectedEmployee.FullName}",
                    Timestamp = DateTime.Now
                });
                ClearForm();
            }
        }

        private void ClearForm()
        {
            SelectedEmployee = new EmployeeModel();
        }

        private void OpenChat()
        {
            var chatWindow = new ChatWindow(chatService, authService.CurrentUser);
            chatWindow.Show();
        }

        private async Task Logout()
        {
            await authService.LogoutAsync();
            notificationService.StopListening();
            System.Windows.Application.Current.Shutdown();
        }

        private void StartChatServer()
        {
            Task.Run(async () =>
            {
                await chatService.StartServerAsync();
            });
        }

        private void StartNotifications()
        {
            notificationService.StartListening();
            notificationService.NotificationReceived += (msg) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    // Показать уведомление
                    Console.WriteLine($"Уведомление: {msg}");
                });
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => canExecute == null || canExecute(parameter);
        public void Execute(object parameter) => execute(parameter);
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}