namespace DiyarTask.Application.Reminders.Commands;

using DiyarTask.Domain.Aggregates.Reminder;
using DiyarTask.Domain.Core;

using MediatR;

public class DeleteReminderCommandHandler : IRequestHandler<DeleteReminderCommand, bool>
{
    private readonly IRepository<Reminder> _reminderRepository;

    public DeleteReminderCommandHandler(IRepository<Reminder> reminderRepository)
    {
        _reminderRepository = reminderRepository;
    }

    public async Task<bool> Handle(DeleteReminderCommand request, CancellationToken cancellationToken)
    {
        var reminder = await _reminderRepository.GetByIdAsync(request.ReminderId);
        if (reminder == null)
        {
            return false;
        }

        await _reminderRepository.DeleteAsync(reminder);
        await _reminderRepository.SaveChangesAsync();

        return true;
    }
}