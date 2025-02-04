using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Domain.Core;

namespace DiyarTask.Domain.Aggregates.Reminder
{
    public class ReminderUser : BaseEntity<Guid>
    {
        public int ReminderId { get; private set; } // Foreign Key to Reminder
        public int CustomerId { get; private set; } // Foreign Key to User (أو Customer)

        public Reminder Reminder { get; private set; }
        public Customer Customer { get; private set; }
    }
}
