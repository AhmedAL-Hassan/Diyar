using DiyarTask.Domain.Core;

namespace DiyarTask.Domain.Aggregates.Reminder
{
    public class Reminder : BaseEntity<Guid>, IAuditableEntity
    {
        // Specifies whether the reminder is set before or after a specific date
        public ReminderTimingEnum ReminderTiming { get; set; } // Before, After

        // The type of duration (e.g., days, weeks, months)
        public ReminderDurationTypeEnum DurationType { get; set; }

        // The number of intervals for the duration
        public int DurationInterval { get; set; }

        // The type of repetition (e.g., daily, weekly, monthly)
        public ReminderRepeatTypeEnum RepeatType { get; set; }

        // The number of repetitions
        public int RepeatCount { get; set; } // may -1 refer to infinite repeating

        public string CreatedBy { get; private set; }
        public string ModifiedBy { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? ModifiedDate { get; private set; }

        public List<ReminderUser> ReminderUsers { get; private set; }
    }

    public enum ReminderRepeatTypeEnum
    {
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
    }

    public enum ReminderDurationTypeEnum
    {
        Days = 1,
        Weeks = 2,
        Months = 3,
    }

    public enum ReminderTimingEnum
    {
        Before = 1,
        After = 2
    }
}
