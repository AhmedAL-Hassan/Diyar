using MediatR;

namespace DiyarTask.Application.Commands.Invoices.DeleteInvoiceCommand
{
    public sealed record DeleteInvoiceCommand(Guid InvoiceId) : IRequest<bool>;
}
