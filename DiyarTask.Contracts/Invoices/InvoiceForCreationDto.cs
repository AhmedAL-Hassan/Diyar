namespace DiyarTask.Contracts.Invoices;

public sealed record InvoiceForCreationDto
{
    public Guid CustomerId { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
}
