namespace DiyarTask.Application.Commands.Invoices.DeleteInvoiceCommand;

using MediatR;

public sealed record DeleteInvoiceCommand(Guid InvoiceId) : IRequest<bool>;