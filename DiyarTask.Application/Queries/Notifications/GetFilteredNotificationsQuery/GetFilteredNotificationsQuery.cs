using DiyarTask.Application.Queries;
using DiyarTask.Domain.Aggregates.NotificationAggregate;
using DiyarTask.Shared.Models.Response.Notification;
using MediatR;
using System.Linq.Expressions;

public class GetFilteredNotificationssQuery : BaseQuery<Notification>, IRequest<List<NotificationDto>>
{
    public Guid? CustomerId { get; set; }
    public SentStatusEnum? SentStatus { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string SortOrder { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    // Method to build dynamic expression based on query parameters
    public Expression<Func<Notification, bool>> BuildExpression()
    {
        Expression<Func<Notification, bool>> filter = n => true; // Default filter that always returns true

        if (CustomerId.HasValue)
            filter = CombineExpressions(filter, n => n.CustomerId == CustomerId.Value);

        if (SentStatus.HasValue)
            filter = CombineExpressions(filter, n => n.SentStatus == SentStatus.Value);

        if (StartDate.HasValue)
            filter = CombineExpressions(filter, n => n.SentDateUtc >= StartDate.Value);

        if (EndDate.HasValue)
            filter = CombineExpressions(filter, n => n.SentDateUtc <= EndDate.Value);

        return filter;
    }

}
