using DiyarTask.Shared.Models.Response.Reminder;
using MediatR;

namespace DiyarTask.Application.Queries.Reminders.GetReminderQuery
{
    public class GetReminderQuery : IRequest<ReminderDto>
    {
        public Guid ReminderId { get; }

        public GetReminderQuery(Guid reminderId)
        {
            ReminderId = reminderId;
        }
    }
}
