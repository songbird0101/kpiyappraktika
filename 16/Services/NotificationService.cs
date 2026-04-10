using System;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManager.Models;

namespace EmployeeManager.Services
{
    public class NotificationService
    {
        private const string MapName = "ScheduleNotificationMap";
        private const int MapSize = 4096;
        private MemoryMappedFile mmf;
        private CancellationTokenSource cts;

        public event Action<string> NotificationReceived;

        public void StartListening()
        {
            cts = new CancellationTokenSource();
            Task.Run(() => ListenForNotifications(cts.Token));
        }

        private void ListenForNotifications(CancellationToken token)
        {
            mmf = MemoryMappedFile.CreateOrOpen(MapName, MapSize);
            var view = mmf.CreateViewAccessor();

            while (!token.IsCancellationRequested)
            {
                byte[] buffer = new byte[MapSize];
                view.ReadArray(0, buffer, 0, MapSize);
                string json = Encoding.UTF8.GetString(buffer).TrimEnd('\0');

                if (!string.IsNullOrEmpty(json))
                {
                    var notification = JsonSerializer.Deserialize<ChatMessage>(json);
                    if (notification != null)
                        NotificationReceived?.Invoke($"[{notification.Department}] {notification.Sender}: {notification.Message}");

                    // Очищаем
                    byte[] empty = new byte[MapSize];
                    view.WriteArray(0, empty, 0, MapSize);
                }
                Thread.Sleep(500);
            }
        }

        public void SendNotification(ChatMessage message)
        {
            using (var mmfSend = MemoryMappedFile.CreateOrOpen(MapName, MapSize))
            using (var view = mmfSend.CreateViewAccessor())
            {
                var json = JsonSerializer.Serialize(message);
                var buffer = Encoding.UTF8.GetBytes(json);
                byte[] padded = new byte[MapSize];
                Array.Copy(buffer, padded, buffer.Length);
                view.WriteArray(0, padded, 0, MapSize);
            }
        }

        public void StopListening()
        {
            cts?.Cancel();
            mmf?.Dispose();
        }
    }
}