namespace DiyarTask.Shared.Models.Response.Reminder;

using DiyarTask.Shared.Enums;

public sealed record ReminderResponse
{
    public Guid Id { get; set; }
    public ReminderTimingEnum ReminderTiming { get; set; }
    public ReminderDurationTypeEnum DurationType { get; set; }
    public ReminderRepeatTypeEnum RepeatType { get; set; }
    public int DurationInterval { get; set; }
    public int RepeatCount { get; set; }
    public string CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}