using DiyarTask.Domain.Core;

namespace DiyarTask.Domain.Aggregates.NotificationAggregate
{
    public class NotificationError : BaseEntity<Guid>
    {
        public DateTime OccurredOnUTC { get; private set; }
        public DateTime OccurredOnLocal { get; private set; }
        public string ErrorMessage { get; private set; }

        public int NotificationId { get; private set; }
        public Notification Notification { get; private set; }
    }
}