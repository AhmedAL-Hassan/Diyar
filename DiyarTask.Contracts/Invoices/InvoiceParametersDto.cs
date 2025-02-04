namespace DiyarTask.Contracts.Invoices;

public sealed class InvoiceParametersDto
{
    public int? CustomerId { get; set; }
    public DateTime? DueDate { get; set; }
    public decimal? MinAmount { get; set; }
    public decimal? MaxAmount { get; set; }
    public int? PaymentStatus { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
