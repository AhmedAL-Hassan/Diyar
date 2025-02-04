using DiyarTask.Domain.Aggregates.Reminder;
using DiyarTask.Domain.Core;
using MediatR;

namespace DiyarTask.Application.Reminders.Commands
{
    public class DeleteReminderCommandHandler : IRequestHandler<DeleteReminderCommand, bool>
    {
        private readonly IRepository<Reminder> _reminderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteReminderCommandHandler(IRepository<Reminder> reminderRepository, IUnitOfWork unitOfWork)
        {
            _reminderRepository = reminderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteReminderCommand request, CancellationToken cancellationToken)
        {
            var reminder = await _reminderRepository.GetByIdAsync(request.ReminderId);
            if (reminder == null)
            {
                // If the reminder is not found, return false (deletion failed).
                return false;
            }

            // Remove the reminder from the repository.
            await _reminderRepository.DeleteAsync(reminder);
            await _unitOfWork.SaveChangesAsync();  // Save changes to persist deletion.

            return true;  // Return true indicating the reminder was successfully deleted.
        }
    }
}
