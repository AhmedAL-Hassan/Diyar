namespace DiyarTask.Domain.Aggregates.Reminder;

using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Domain.Core;

public class ReminderUser : BaseEntity<Guid>
{
    public Guid ReminderId { get; private set; }
    public Reminder Reminder { get; private set; }

    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; }
}