namespace DiyarTask.Contracts.Notifications;

using ReminderTaskManagement.Resources;

public sealed class NotificationParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
