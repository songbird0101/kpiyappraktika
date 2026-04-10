using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using EmployeeManager.Models;
using EmployeeManager.Services;

namespace EmployeeManager.ViewModels
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private readonly ChatService chatService;
        private readonly UserModel currentUser;
        private string messageText;
        private ObservableCollection<ChatMessage> messages;

        public ObservableCollection<ChatMessage> Messages
        {
            get { return messages; }
            set { messages = value; OnPropertyChanged(); }
        }

        public string MessageText
        {
            get { return messageText; }
            set { messageText = value; OnPropertyChanged(); }
        }

        public ICommand SendCommand { get; }

        public ChatViewModel(ChatService chatService, UserModel currentUser)
        {
            this.chatService = chatService;
            this.currentUser = currentUser;
            Messages = new ObservableCollection<ChatMessage>();

            chatService.MessageReceived += OnMessageReceived;
            SendCommand = new RelayCommand(async _ => await SendMessage());
        }

        private void OnMessageReceived(ChatMessage message)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add(message);
            });
        }

        private async Task SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(MessageText))
            {
                var message = new ChatMessage
                {
                    Sender = currentUser.Username,
                    Department = currentUser.Department,
                    Message = MessageText,
                    Timestamp = System.DateTime.Now
                };
                await chatService.SendMessageAsync(message);
                Messages.Add(message);
                MessageText = "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}