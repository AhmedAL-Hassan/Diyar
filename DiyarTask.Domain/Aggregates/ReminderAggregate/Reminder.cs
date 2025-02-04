using DiyarTask.Domain.Aggregates.ReminderAggregate.Interfaces;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Enums;

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

        public static Reminder AddReminder(ICreateReminderCommand request)
        {
            return new Reminder
            {
                Id = Guid.NewGuid(),
                ReminderTiming = request.ReminderTiming,
                DurationType = request.DurationType,
                DurationInterval = request.DurationInterval,
                RepeatType = request.RepeatType,
                RepeatCount = request.RepeatCount,
                CreatedDate = DateTime.UtcNow
            };
        }

        // Method to update an existing Reminder
        public void UpdateReminder(IUpdateReminderCommand request)
        {
            ReminderTiming = request.ReminderTiming;
            DurationType = request.DurationType;
            DurationInterval = request.DurationInterval;
            RepeatType = request.RepeatType;
            RepeatCount = request.RepeatCount;
            ModifiedDate = DateTime.UtcNow;
            ModifiedBy = request.ModifiedBy;
        }
    }
}
