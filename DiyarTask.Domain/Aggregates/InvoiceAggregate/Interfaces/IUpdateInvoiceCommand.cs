namespace DiyarTask.Domain.Aggregates.InvoiceAggregate.Interfaces
{
    public interface IUpdateInvoiceCommand
    {
        DateTime DueDate { get; }
        decimal Amount { get; }
        PaymentStatusEnum PaymentStatus { get; }    
    }
}
