namespace DiyarTask.Application.Commands.Invoices.UpdateInvoiceCommand;

using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Core.Errors;
using DiyarTask.Shared.Models.Response.Invoice;

using MapsterMapper;

using MediatR;

public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, InvoiceResponse>
{
    private readonly IRepository<Invoice> _invoiceRepository;
    private readonly IMapper _mapper;

    public UpdateInvoiceCommandHandler(IRepository<Invoice> InvoiceRepository, IMapper mapper)
    {
        _invoiceRepository = InvoiceRepository;
        _mapper = mapper;
    }

    public async Task<InvoiceResponse> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var Invoice = await _invoiceRepository.GetByIdAsync(request.Id);
        if (Invoice is null)
        {
            throw new NotFoundException($"Invoice with ID {request.Id} not found.");
        }

        Invoice.UpdateInvoice(request);

        await _invoiceRepository.UpdateAsync(Invoice);
        await _invoiceRepository.SaveChangesAsync();

        return _mapper.Map<InvoiceResponse>(Invoice);
    }
}