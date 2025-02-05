namespace DiyarTask.Shared.Models.Response.Invoice;

public sealed record InvoiceResponse
{
    public Guid Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime DueDateUtc { get; set; }
    public DateTime DueDateLocal { get; set; }
    public decimal Amount { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}