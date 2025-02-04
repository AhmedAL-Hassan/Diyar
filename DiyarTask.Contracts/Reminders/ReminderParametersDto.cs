using DiyarTask.Shared.Enums;

namespace DiyarTask.Contracts.Reminders;

public sealed class ReminderParametersDto
{
    public ReminderTimingEnum? ReminderTiming { get; set; } // Before, After
    public ReminderDurationTypeEnum? DurationType { get; set; } // Days, Weeks, Months
    public int? DurationInterval { get; set; } // Number of intervals
    public ReminderRepeatTypeEnum? RepeatType { get; set; } // Daily, Weekly, Monthly
    public int? RepeatCount { get; set; } // -1 for infinite repetitions
    public string? SortOrder { get; set; } // Sorting field (e.g., "CreatedDate DESC")
    public int PageNumber { get; set; } = 1; // Default to first page
    public int PageSize { get; set; } = 10; // Default page size
}

