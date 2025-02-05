namespace DiyarTask.Application.Reminders.Commands;

using MediatR;

public sealed class DeleteReminderCommand : IRequest<bool>
{
    public DeleteReminderCommand(Guid reminderId)
    {
        ReminderId = reminderId;
    }

    public Guid ReminderId { get; }
}