using DiyarTask.Domain.Aggregates.Reminder;
using DiyarTask.Shared.Enums;
using DiyarTask.Shared.Models.Response.Reminder;
using MediatR;
using System.Linq.Expressions;

namespace DiyarTask.Application.Queries.Reminders.GetFilteredRemindersQuery
{
    public class GetFilteredRemindersQuery : BaseQuery<Reminder>, IRequest<List<ReminderResponse>>
    {
        public ReminderTimingEnum? ReminderTiming { get; set; }
        public ReminderDurationTypeEnum? DurationType { get; set; }
        public int? DurationInterval { get; set; }
        public ReminderRepeatTypeEnum? RepeatType { get; set; }
        public int? RepeatCount { get; set; }
        public string SortOrder { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public Expression<Func<Reminder, bool>> BuildExpression()
        {
            Expression<Func<Reminder, bool>> filter = r => true; // Default to always true condition

            if (ReminderTiming.HasValue)
                filter = CombineExpressions(filter, r => r.ReminderTiming == ReminderTiming.Value);

            if (DurationType.HasValue)
                filter = CombineExpressions(filter, r => r.DurationType == DurationType.Value);

            if (DurationInterval.HasValue)
                filter = CombineExpressions(filter, r => r.DurationInterval == DurationInterval.Value);

            if (RepeatType.HasValue)
                filter = CombineExpressions(filter, r => r.RepeatType == RepeatType.Value);

            if (RepeatCount.HasValue)
                filter = CombineExpressions(filter, r => r.RepeatCount == RepeatCount.Value);

            return filter;
        }
    }
}
