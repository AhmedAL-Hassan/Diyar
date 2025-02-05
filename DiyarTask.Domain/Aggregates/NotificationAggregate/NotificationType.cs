namespace DiyarTask.Domain.Aggregates.NotificationAggregate;

using DiyarTask.Domain.Core;

public class NotificationType : BaseEntity<int>
{
    public string TypeName { get; private set; }
    public string Description { get; private set; }
    public List<NotificationTemplate> NotificationTemplates { get; private set; }
}

public enum NotificationTypeEnum : int
{
    Web = 1,
    Sms = 2,
    Email = 3
}