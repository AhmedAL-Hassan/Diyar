using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Notification;

namespace DiyarTask.Infrastructure.Services.Notification.Web
{
    public class WebNotificationService : INotificationService
    {
        public async Task SendAsync(NotificationData data)
        {
            // Simulate sending web notification
            await Task.Delay(500);
            Console.WriteLine($"Web notification sent to {data.UserId}: {data.Message}");
        }
    }
}
