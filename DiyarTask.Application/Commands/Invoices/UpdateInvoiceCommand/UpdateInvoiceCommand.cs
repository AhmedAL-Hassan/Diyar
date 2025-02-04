using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Aggregates.InvoiceAggregate.Interfaces;
using DiyarTask.Shared.Models.Response.Invoice;
using MediatR;

namespace DiyarTask.Application.Commands.Invoices.UpdateInvoiceCommand
{
    public sealed class UpdateInvoiceCommand : IRequest<InvoiceDto>, IUpdateInvoiceCommand
    {
        public Guid Id { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; }
    }
}
