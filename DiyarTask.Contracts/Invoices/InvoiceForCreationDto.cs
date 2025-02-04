namespace DiyarTask.Contracts.Invoices;

public sealed record InvoiceForCreationDto
{
    public int CustomerId { get; set; }
    public DateTime DueDateUtc { get; set; }
    public DateTime DueDateLocal { get; set; }
    public decimal Amount { get; set; }
}
