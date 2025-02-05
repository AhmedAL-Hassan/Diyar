namespace DiyarTask.Domain.Aggregates.InvoiceAggregate;

using DiyarTask.Domain.Core;

public class PaymentError : BaseEntity<Guid>
{
    public DateTime OccurredOnUTC { get; set; }
    public DateTime OccurredOnLocal { get; set; }
    public string ErrorMessage { get; set; }
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
}