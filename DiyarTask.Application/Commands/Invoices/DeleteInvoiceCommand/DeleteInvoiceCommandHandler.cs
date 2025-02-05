namespace DiyarTask.Application.Commands.Invoices.DeleteInvoiceCommand;

using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Core.Errors;

using MediatR;

public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, bool>
{
    private readonly IRepository<Invoice> _invoiceRepository;

    public DeleteInvoiceCommandHandler(IRepository<Invoice> InvoiceRepository)
    {
        _invoiceRepository = InvoiceRepository;
    }

    public async Task<bool> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {
        var Invoice = await _invoiceRepository.GetByIdAsync(request.InvoiceId);
        if (Invoice is null)
        {
            throw new NotFoundException($"Invoice with ID {request.InvoiceId} not found.");
        }

        await _invoiceRepository.DeleteAsync(Invoice);
        await _invoiceRepository.SaveChangesAsync();

        return true;
    }
}