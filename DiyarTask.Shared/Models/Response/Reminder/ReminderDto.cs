using DiyarTask.Shared.Enums;

namespace DiyarTask.Shared.Models.Response.Reminder;

public sealed record ReminderDto
{
    public Guid Id { get; set; }
    public ReminderTimingEnum ReminderTiming { get; set; } // Before, After
    public ReminderDurationTypeEnum DurationType { get; set; } // Days, Weeks, Months
    public int DurationInterval { get; set; } // Number of intervals
    public ReminderRepeatTypeEnum RepeatType { get; set; } // Daily, Weekly, Monthly
    public int RepeatCount { get; set; } // -1 for infinite repetitions
    public string CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

