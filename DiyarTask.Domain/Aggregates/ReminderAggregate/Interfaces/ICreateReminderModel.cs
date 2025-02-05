using DiyarTask.Shared.Enums;

namespace DiyarTask.Domain.Aggregates.ReminderAggregate.Interfaces
{
    public interface ICreateReminderModel
    {
        ReminderTimingEnum ReminderTiming { get; set; }
        ReminderDurationTypeEnum DurationType { get; set; }
        int DurationInterval { get; set; }
        ReminderRepeatTypeEnum RepeatType { get; set; }
        int RepeatCount { get; set; }
    }
}
