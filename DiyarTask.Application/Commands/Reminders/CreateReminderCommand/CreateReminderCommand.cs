namespace DiyarTask.Application.Commands.Reminders.CreateReminderCommand;

using DiyarTask.Domain.Aggregates.ReminderAggregate;
using DiyarTask.Domain.Aggregates.ReminderAggregate.Interfaces;
using DiyarTask.Shared.Enums;
using DiyarTask.Shared.Models.Response.Reminder;
using MediatR;
using System;

public sealed class CreateReminderCommand : IRequest<ReminderDto>, ICreateReminderCommand
{
    public ReminderTimingEnum ReminderTiming { get; set; }
    public ReminderDurationTypeEnum DurationType { get; set; }
    public int DurationInterval { get; set; }
    public ReminderRepeatTypeEnum RepeatType { get; set; }
    public int RepeatCount { get; set; }
}