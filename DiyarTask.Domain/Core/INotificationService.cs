using DiyarTask.Shared.Models.Notification;

namespace DiyarTask.Domain.Core
{
    public interface INotificationService
    {
        Task SendAsync(NotificationData message);
    }

}
