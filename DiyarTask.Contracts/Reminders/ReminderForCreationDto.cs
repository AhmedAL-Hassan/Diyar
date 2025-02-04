using DiyarTask.Shared.Enums;

namespace DiyarTask.Contracts.Reminders;

public sealed record ReminderForCreationDto
{
   public ReminderTimingEnum ReminderTiming { get; set; } // Before, After
   public ReminderDurationTypeEnum DurationType { get; set; } // Days, Weeks, Months
   public int DurationInterval { get; set; }
   public ReminderRepeatTypeEnum RepeatType { get; set; } // Daily, Weekly, Monthly
   public int RepeatCount { get; set; } // -1 for infinite repeating
}
