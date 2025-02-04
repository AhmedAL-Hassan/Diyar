namespace DiyarTask.Domain.Aggregates.InvoiceAggregate.Interfaces
{
    public interface ICreateInvoiceCommand
    {
        int CustomerId { get; }
        DateTime DueDate { get; }
        decimal Amount { get; }
        PaymentStatusEnum PaymentStatus { get; }
    }
}
