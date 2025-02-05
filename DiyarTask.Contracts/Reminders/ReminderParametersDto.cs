namespace DiyarTask.Contracts.Reminders;

using DiyarTask.Shared.Enums;

public sealed class ReminderParametersDto
{
    public ReminderTimingEnum? ReminderTiming { get; set; }
    public ReminderDurationTypeEnum? DurationType { get; set; }
    public int? DurationInterval { get; set; }
    public ReminderRepeatTypeEnum? RepeatType { get; set; }
    public int? RepeatCount { get; set; }
    public string? SortOrder { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}