using DiyarTask.Domain.Aggregates.Reminder;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Response.Reminder;
using MapsterMapper;
using MediatR;

namespace DiyarTask.Application.Queries.Reminders.GetFilteredRemindersQuery
{
    public sealed class GetFilteredRemindersQueryHandler : IRequestHandler<GetFilteredRemindersQuery, List<ReminderDto>>
    {
        private readonly IRepository<Reminder> _ReminderRepository;
        private readonly IMapper _mapper;

        public GetFilteredRemindersQueryHandler(IRepository<Reminder> ReminderRepository, IMapper mapper)
        {
            _ReminderRepository = ReminderRepository;
            _mapper = mapper;
        }

        public async Task<List<ReminderDto>> Handle(GetFilteredRemindersQuery request, CancellationToken cancellationToken)
        {
            var expression = request.BuildExpression();

            var Reminders = _ReminderRepository.GetFilteredAsync(expression);

            return _mapper.Map<List<ReminderDto>>(Reminders);
        }
    }
}