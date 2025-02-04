using MediatR;

namespace DiyarTask.Application.Reminders.Commands
{
    public sealed class DeleteReminderCommand : IRequest<bool>  // Returns a boolean indicating success or failure
    {
        public Guid ReminderId { get; }

        public DeleteReminderCommand(Guid reminderId)
        {
            ReminderId = reminderId;
        }
    }
}
