using DiyarTask.Domain.Aggregates.ReminderAggregate.Interfaces;
using DiyarTask.Shared.Enums;
using DiyarTask.Shared.Models.Response.Reminder;
using MediatR;

namespace DiyarTask.Application.Commands.Reminders.UpdateReminderCommand
{
    public class UpdateReminderCommand : IRequest<ReminderResponse>, IUpdateReminderCommand
    {
        public Guid ReminderId { get; set; }
        public ReminderTimingEnum ReminderTiming { get; set; }
        public ReminderDurationTypeEnum DurationType { get; set; }
        public int DurationInterval { get; set; }
        public ReminderRepeatTypeEnum RepeatType { get; set; }
        public int RepeatCount { get; set; }
    }
}
