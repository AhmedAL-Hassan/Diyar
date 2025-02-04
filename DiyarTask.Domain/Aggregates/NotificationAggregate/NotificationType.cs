using DiyarTask.Domain.Core;

namespace DiyarTask.Domain.Aggregates.NotificationAggregate
{
    public class NotificationType : BaseEntity<NotificationTypeEnum>
    {
        public string TypeName { get; private set; }
        public string Description { get; private set; }

        // Navigation Properties
        public List<NotificationTemplate> NotificationTemplates { get; private set; }
        public List<Notification> Notifications { get; private set; }
    }

    public enum NotificationTypeEnum : int
    {
        Web = 1,
        Sms = 2,
        Email = 3
    }
}
