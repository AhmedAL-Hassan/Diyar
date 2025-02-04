using DiyarTask.Domain.Core;

namespace DiyarTask.Domain.Aggregates.InvoiceAggregate
{
    public class PaymentError : BaseEntity<Guid>
    {
        public int InvoiceId { get; set; } 
        public DateTime OccurredOnUTC { get; set; } 
        public DateTime OccurredOnLocal { get; set; } 
        public string ErrorMessage { get; set; } 
        public Invoice Invoice { get; set; }
    }
}
