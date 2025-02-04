using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Domain.Core;

namespace DiyarTask.Domain.Aggregates.NotificationAggregate
{
    public class Notification : BaseEntity<Guid>
    {
        public int NotificationId { get; private set; }
        public int CustomerId { get; private set; }

        public string Message { get; private set; }
        public DateTime SentDateUtc { get; private set; }
        public DateTime SentDateLocal { get; private set; }
        public SentStatusEnum SentStatus { get; private set; } // sent, failed
        public NotificationError NotificationError { get; private set; } // error
        public Customer Customer { get; private set; }
        public int NotificationTemplateId { get; private set; }
        public NotificationTemplate NotificationTemplate { get; private set; }
    }

    public enum SentStatusEnum
    {
        Sent = 1,
        Failed = 2
    }
}
