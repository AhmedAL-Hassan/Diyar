namespace DiyarTask.Application.Commands.Invoices.CreateInvoiceCommand;

using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Response.Invoice;
using MapsterMapper;
using MediatR;

public sealed class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, InvoiceDto>
{
    private readonly IRepository<Invoice> _InvoiceRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateInvoiceCommandHandler(IRepository<Invoice> InvoiceRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _InvoiceRepository = InvoiceRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<InvoiceDto> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        // Map command to entity
        var invoice = Invoice.AddInvoice(request);

            // Save to database
        await _InvoiceRepository.AddAsync(invoice);
        await _unitOfWork.SaveChangesAsync();

        // Return mapped DTO
        return _mapper.Map<InvoiceDto>(invoice);
    }
}
