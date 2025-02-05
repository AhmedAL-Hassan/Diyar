namespace DiyarTask.Application.Commands.Invoices.CreateInvoiceCommand;

using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Response.Invoice;

using MapsterMapper;

using MediatR;

public sealed class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, InvoiceResponse>
{
    private readonly IRepository<Invoice> _invoiceRepository;
    private readonly IMapper _mapper;

    public CreateInvoiceCommandHandler(IRepository<Invoice> InvoiceRepository, IMapper mapper)
    {
        _invoiceRepository = InvoiceRepository;
        _mapper = mapper;
    }

    public async Task<InvoiceResponse> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = Invoice.AddInvoice(request);

        await _invoiceRepository.AddAsync(invoice);
        await _invoiceRepository.SaveChangesAsync();

        return _mapper.Map<InvoiceResponse>(invoice);
    }
}