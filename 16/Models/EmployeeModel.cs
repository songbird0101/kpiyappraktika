using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmployeeManager.Models
{
    public class EmployeeModel : INotifyPropertyChanged
    {
        private int id;
        private string fullName;
        private string position;
        private string department;
        private string phone;
        private string email;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; OnPropertyChanged(); }
        }

        public string Position
        {
            get { return position; }
            set { position = value; OnPropertyChanged(); }
        }

        public string Department
        {
            get { return department; }
            set { department = value; OnPropertyChanged(); }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}