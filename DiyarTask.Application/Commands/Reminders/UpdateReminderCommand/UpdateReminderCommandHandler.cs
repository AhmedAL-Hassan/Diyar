namespace DiyarTask.Application.Reminders.Handlers;

using DiyarTask.Application.Commands.Reminders.UpdateReminderCommand;
using DiyarTask.Domain.Aggregates.Reminder;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Core.Errors;
using DiyarTask.Shared.Models.Response.Reminder;

using MapsterMapper;

using MediatR;

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
        var reminder = await _reminderRepository.GetByIdAsync(request.ReminderId);

        if (reminder == null)
        {
            throw new NotFoundException($"Reminder {request.ReminderId}");
        }

        reminder.UpdateReminder(request);

        await _reminderRepository.UpdateAsync(reminder);
        await _unitOfWork.SaveChangesAsync();

        var reminderDto = _mapper.Map<ReminderDto>(reminder);

        return reminderDto;
    }
}