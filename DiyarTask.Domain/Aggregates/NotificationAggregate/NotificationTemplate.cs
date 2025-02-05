namespace DiyarTask.Domain.Aggregates.NotificationAggregate;

using DiyarTask.Domain.Core;

public class NotificationTemplate : BaseEntity<Guid>
{
    public string TemplateName { get; private set; }

    public string TemplateContent { get; private set; }

    public int NotificationTypeId { get; private set; }
    public NotificationType NotificationType { get; private set; }

    public List<Notification> Notifications { get; private set; }
}