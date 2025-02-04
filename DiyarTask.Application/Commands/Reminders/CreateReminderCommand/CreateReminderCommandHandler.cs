using MediatR;
using DiyarTask.Domain.Aggregates.Reminder;
using DiyarTask.Application.Commands.Reminders.CreateReminderCommand;
using DiyarTask.Shared.Models.Response.Reminder;
using MapsterMapper;
using DiyarTask.Domain.Core;

public sealed class CreateReminderCommandHandler : IRequestHandler<CreateReminderCommand, ReminderDto>
{
    private readonly IRepository<Reminder> _reminderRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReminderCommandHandler(IRepository<Reminder> reminderRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _reminderRepository = reminderRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ReminderDto> Handle(CreateReminderCommand request, CancellationToken cancellationToken)
    {
        var reminder = Reminder.AddReminder(request);

        await _reminderRepository.AddAsync(reminder);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<ReminderDto>(reminder);
    }
}
