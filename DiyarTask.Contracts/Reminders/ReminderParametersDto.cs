namespace DiyarTask.Contracts.Reminders;

using ReminderTaskManagement.Resources;

public sealed class ReminderParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
