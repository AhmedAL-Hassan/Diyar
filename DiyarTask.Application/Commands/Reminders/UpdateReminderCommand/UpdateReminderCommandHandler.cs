using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DiyarTask.Application.Reminders.Commands;
using DiyarTask.Domain.Aggregates.Reminder;
using DiyarTask.Application.Common.Interfaces;
using AutoMapper;
using DiyarTask.Application.Commands.Reminders.UpdateReminderCommand;
using DiyarTask.Shared.Core.Errors;
using DiyarTask.Shared.Models.Response.Reminder;
using MapsterMapper;
using DiyarTask.Domain.Core;

namespace DiyarTask.Application.Reminders.Handlers
{
    public class UpdateReminderCommandHandler : IRequestHandler<UpdateReminderCommand, ReminderDto>
    {
        private readonly IRepository<Reminder> _reminderRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateReminderCommandHandler(IRepository<Reminder> reminderRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _reminderRepository = reminderRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ReminderDto> Handle(UpdateReminderCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the existing reminder by ID
            var reminder = await _reminderRepository.GetByIdAsync(request.ReminderId);

            if (reminder == null)
            {
                // Handle case where reminder doesn't exist
                throw new NotFoundException($"Reminder {request.ReminderId}");
            }

            // Update the reminder using the data from the command
            reminder.UpdateReminder(request);

            // Save the changes to the repository
            await _reminderRepository.UpdateAsync(reminder);
            await _unitOfWork.SaveChangesAsync();

            // Map the updated reminder to a DTO to return as a response
            var reminderDto = _mapper.Map<ReminderDto>(reminder);

            return reminderDto;
        }
    }
}
