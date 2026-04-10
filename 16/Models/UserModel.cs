using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmployeeManager.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        private int id;
        private string username;
        private string passwordHash;
        private string department;
        private bool isLoggedIn;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        public string PasswordHash
        {
            get { return passwordHash; }
            set { passwordHash = value; OnPropertyChanged(); }
        }

        public string Department
        {
            get { return department; }
            set { department = value; OnPropertyChanged(); }
        }

        public bool IsLoggedIn
        {
            get { return isLoggedIn; }
            set { isLoggedIn = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}