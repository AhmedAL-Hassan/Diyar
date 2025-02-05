namespace DiyarTask.Domain.Aggregates.InvoiceAggregate;

using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Domain.Aggregates.InvoiceAggregate.Interfaces;
using DiyarTask.Domain.Core;

public sealed class Invoice : BaseEntity<Guid>, IAuditableEntity
{
    public DateTime DueDate { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatusEnum PaymentStatus { get; private set; }
    public PaymentError PaymentError { get; private set; }
    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; }
    public string CreatedBy { get; private set; }
    public string ModifiedBy { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime? ModifiedDate { get; private set; }

    public static Invoice AddInvoice(ICreateInvoiceCommand request)
    {
        return new Invoice
        {
            Id = Guid.NewGuid(),
            CustomerId = request.CustomerId,
            DueDate = request.DueDate,
            Amount = request.Amount,
            PaymentStatus = PaymentStatusEnum.Unpaid,
            CreatedDate = DateTime.UtcNow
        };
    }

    public void UpdateInvoice(IUpdateInvoiceCommand request)
    {
        DueDate = request.DueDate;
        Amount = request.Amount;
        PaymentStatus = request.PaymentStatus;
        ModifiedDate = DateTime.UtcNow;
    }
}

public enum PaymentStatusEnum
{
    Unpaid = 0,
    Paid = 1,
    PartiallyPaid = 2,
    Error = 3
}