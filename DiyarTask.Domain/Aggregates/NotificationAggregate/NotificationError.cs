namespace DiyarTask.Domain.Aggregates.NotificationAggregate;

using DiyarTask.Domain.Core;

public class NotificationError : BaseEntity<Guid>
{
    public DateTime OccurredOnUTC { get; private set; }
    public DateTime OccurredOnLocal { get; private set; }
    public string ErrorMessage { get; private set; }
    public Guid NotificationId { get; private set; }
    public Notification Notification { get; private set; }
}