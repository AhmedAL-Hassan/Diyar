using DiyarTask.Domain.Aggregates.Reminder;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Response.Reminder;
using MapsterMapper;
using MediatR;

namespace DiyarTask.Application.Queries.Reminders.GetReminderQuery
{
    public class GetReminderQueryHandler : IRequestHandler<GetReminderQuery, ReminderDto>
    {
        private readonly IRepository<Reminder> _reminderRepository;
        private readonly IMapper _mapper;
        public GetReminderQueryHandler(IRepository<Reminder> reminderRepository, IMapper mapper)
        {
            _reminderRepository = reminderRepository;
            _mapper = mapper;
        }

        public async Task<ReminderDto> Handle(GetReminderQuery request, CancellationToken cancellationToken)
        {
            var reminder = await _reminderRepository.GetByIdAsync(request.ReminderId);

            if (reminder == null)
            {
                // Handle not found (return null or throw exception as needed)
                return null;  // You can throw a custom exception here if needed
            }

            // Map the Reminder entity to the DTO (ReminderDto)
            var reminderDto = _mapper.Map<ReminderDto>(reminder);

            return reminderDto;
        }
    }
}
