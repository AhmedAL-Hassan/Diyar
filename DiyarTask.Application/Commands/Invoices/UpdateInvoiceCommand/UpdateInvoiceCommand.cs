namespace DiyarTask.Application.Commands.Invoices.UpdateInvoiceCommand;

using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Aggregates.InvoiceAggregate.Interfaces;
using DiyarTask.Shared.Models.Response.Invoice;

using MediatR;

public sealed class UpdateInvoiceCommand : IRequest<InvoiceResponse>, IUpdateInvoiceModel
{
    public Guid Id { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatusEnum PaymentStatus { get; set; }
}