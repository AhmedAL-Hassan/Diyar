using DiyarTask.Domain.Aggregates.NotificationAggregate;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Response.Notification;
using MapsterMapper;
using MediatR;

public class GetFilteredNotificationssQueryHandler : IRequestHandler<GetFilteredNotificationssQuery, List<NotificationDto>>
{
    private readonly IRepository<Notification> _notificationRepository;
    private readonly IMapper _mapper;

    public GetFilteredNotificationssQueryHandler(IRepository<Notification> notificationRepository, IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }

    public async Task<List<NotificationDto>> Handle(GetFilteredNotificationssQuery request, CancellationToken cancellationToken)
    {
        var filterExpression = request.BuildExpression(); // Build the dynamic filter expression

        // Query the repository and apply the filter expression
        //var paginatedNotifications = query
        //    .Skip((request.PageNumber - 1) * request.PageSize)
        //    .Take(request.PageSize);

        var result = _notificationRepository.GetFilteredAsync(filterExpression);

        var resultDto = _mapper.Map<List<NotificationDto>>(result);

        return resultDto;
    }

    // Helper method to apply sorting
    //private IQueryable<Notification> ApplySorting(IQueryable<Notification> query, string sortOrder)
    //{
    //    Implement sorting logic, for example:
    //    if (sortOrder == "SentDateUtc DESC")
    //        {
    //            return query.OrderByDescending(n => n.SentDateUtc);
    //        }
    //    return query.OrderBy(n => n.SentDateUtc); // Default sorting
    //}
}
