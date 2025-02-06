using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Notification;

namespace DiyarTask.Infrastructure.Services.Notification.Email
{
    public class EmailNotificationService : INotificationService
    {
        public async Task SendAsync(NotificationData data)
        {
            // Simulate sending email
            await Task.Delay(500);
            Console.WriteLine($"Email sent to {data.Recipient}: {data.Message}");
        }
    }
}
