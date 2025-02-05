namespace DiyarTask.Domain.Aggregates.InvoiceAggregate.Interfaces
{
    public interface IUpdateInvoiceModel
    {
        DateTime DueDate { get; }
        decimal Amount { get; }
        PaymentStatusEnum PaymentStatus { get; }    
    }
}
