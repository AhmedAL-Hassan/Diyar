using DiyarTask.Domain.Core;

namespace DiyarTask.Domain.Aggregates.NotificationAggregate
{
    public class NotificationTemplate : BaseEntity<Guid>
    {
        public string TemplateName { get; private set; }

        public string TemplateContent { get; private set; } // "Dear {0}, your invoice is due on {1} with amount {2}"

        public int NotificationTypeId { get; private set; }
        public NotificationType NotificationType { get; private set; }

        public List<Notification> Notifications { get; private set; }
    }
}