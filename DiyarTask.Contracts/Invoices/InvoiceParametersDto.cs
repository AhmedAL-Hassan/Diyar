namespace DiyarTask.Contracts.Invoices;

using ReminderTaskManagement.Resources;

public sealed class InvoiceParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
