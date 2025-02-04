using DiyarTask.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyarTask.Domain.Aggregates.ReminderAggregate.Interfaces
{
    public interface IUpdateReminderCommand
    {
        Guid ReminderId { get; set; }
        ReminderTimingEnum ReminderTiming { get; set; }
        ReminderDurationTypeEnum DurationType { get; set; }
        int DurationInterval { get; set; }
        ReminderRepeatTypeEnum RepeatType { get; set; }
        int RepeatCount { get; set; }
    }
}
