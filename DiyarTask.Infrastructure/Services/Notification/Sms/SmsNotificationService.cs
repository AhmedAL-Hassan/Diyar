using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Notification;

namespace DiyarTask.Infrastructure.Services.Notification.Sms
{
    public class SmsNotificationService : INotificationService
    {
        public async Task SendAsync(NotificationData data)
        {
            // Simulate sending SMS
            await Task.Delay(500);
            Console.WriteLine($"SMS sent to {data.UserPhoneNumber}: {data.Message}");
        }
    }

}
