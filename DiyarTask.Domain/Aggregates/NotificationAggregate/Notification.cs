namespace DiyarTask.Domain.Aggregates.NotificationAggregate;

using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Domain.Core;

public class Notification : BaseEntity<Guid>
{
    public Guid CustomerId { get; private set; }
    public string Message { get; private set; }
    public DateTime SentDateUtc { get; private set; }
    public DateTime SentDateLocal { get; private set; }
    public SentStatusEnum SentStatus { get; private set; }
    public NotificationError NotificationError { get; private set; }
    public Customer Customer { get; private set; }
    public Guid NotificationTemplateId { get; private set; }
    public NotificationTemplate NotificationTemplate { get; private set; }
}

public enum SentStatusEnum
{
    Sent = 1,
    Failed = 2
}