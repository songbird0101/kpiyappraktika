using System;
using System.IO.Pipes;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeManager.Models;

namespace EmployeeManager.Services
{
    public class ChatService
    {
        private const string PipeName = "EmployeeChatPipe";
        private NamedPipeServerStream serverStream;
        private NamedPipeClientStream clientStream;

        public event Action<ChatMessage> MessageReceived;

        public async Task StartServerAsync()
        {
            await Task.Run(() =>
            {
                serverStream = new NamedPipeServerStream(PipeName, PipeDirection.InOut, 10);
                serverStream.WaitForConnection();

                while (serverStream.IsConnected)
                {
                    var buffer = new byte[4096];
                    int bytesRead = serverStream.Read(buffer, 0, buffer.Length);
                    var json = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    var message = JsonSerializer.Deserialize<ChatMessage>(json);
                    MessageReceived?.Invoke(message);
                }
            });
        }

        public async Task SendMessageAsync(ChatMessage message)
        {
            await Task.Run(() =>
            {
                using (var client = new NamedPipeClientStream(".", PipeName, PipeDirection.Out))
                {
                    client.Connect(1000);
                    var json = JsonSerializer.Serialize(message);
                    var buffer = Encoding.UTF8.GetBytes(json);
                    client.Write(buffer, 0, buffer.Length);
                    client.Flush();
                }
            });
        }
    }
}