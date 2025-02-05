namespace DiyarTask.Contracts.Notifications;

using DiyarTask.Domain.Aggregates.NotificationAggregate;

public sealed class NotificationsParametersDto
{
    public int? CustomerId { get; set; } // Customer ID to filter notifications
    public SentStatusEnum? SentStatus { get; set; } // Sent or Failed status
    public DateTime? StartDate { get; set; } // Filter by the sent date range start
    public DateTime? EndDate { get; set; } // Filter by the sent date range end
    public string SortOrder { get; set; } // Sorting (by default, descending SentDateUtc)
    public int PageNumber { get; set; } = 1; // Default to the first page
    public int PageSize { get; set; } = 10; // Default to page size 10
}
