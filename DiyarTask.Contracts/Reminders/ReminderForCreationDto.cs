namespace DiyarTask.Contracts.Reminders;

using DiyarTask.Shared.Enums;

public sealed record ReminderForCreationDto
{
    public ReminderTimingEnum ReminderTiming { get; set; }
    public ReminderDurationTypeEnum DurationType { get; set; }
    public int DurationInterval { get; set; }
    public ReminderRepeatTypeEnum RepeatType { get; set; }
    public int RepeatCount { get; set; }
}