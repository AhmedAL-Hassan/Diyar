namespace DiyarTask.Application.Commands.Reminders.CreateReminderCommand;

using DiyarTask.Domain.Aggregates.Reminder;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Response.Reminder;

using MapsterMapper;

using MediatR;

public sealed class CreateReminderCommandHandler : IRequestHandler<CreateReminderCommand, ReminderResponse>
{
    private readonly IRepository<Reminder> _reminderRepository;
    private readonly IMapper _mapper;

    public CreateReminderCommandHandler(IRepository<Reminder> reminderRepository, IMapper mapper)
    {
        _reminderRepository = reminderRepository;
        _mapper = mapper;
    }

    public async Task<ReminderResponse> Handle(CreateReminderCommand request, CancellationToken cancellationToken)
    {
        var reminder = Reminder.AddReminder(request);

        await _reminderRepository.AddAsync(reminder);
        await _reminderRepository.SaveChangesAsync();

        return _mapper.Map<ReminderResponse>(reminder);
    }
}