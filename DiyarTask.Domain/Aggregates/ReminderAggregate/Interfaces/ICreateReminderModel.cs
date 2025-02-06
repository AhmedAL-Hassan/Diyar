using DiyarTask.Shared.Enums;

namespace DiyarTask.Domain.Aggregates.ReminderAggregate.Interfaces
{
    public interface ICreateReminderModel
    {
        public List<Guid> CustomerIds { get; set; }
        ReminderTimingEnum ReminderTiming { get; set; }
        ReminderDurationTypeEnum DurationType { get; set; }
        int DurationInterval { get; set; }
        ReminderRepeatTypeEnum RepeatType { get; set; }
        int RepeatCount { get; set; }
    }
}
