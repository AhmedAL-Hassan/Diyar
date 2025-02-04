using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Core.Errors;
using DiyarTask.Shared.Models.Response.Invoice;
using MapsterMapper;
using MediatR;

namespace DiyarTask.Application.Commands.Invoices.UpdateInvoiceCommand
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, InvoiceDto>
    {
        private readonly IRepository<Invoice> _InvoiceRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateInvoiceCommandHandler(IRepository<Invoice> InvoiceRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _InvoiceRepository = InvoiceRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<InvoiceDto> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            // Fetch the existing Invoice from the database
            var Invoice = await _InvoiceRepository.GetByIdAsync(request.Id);
            if (Invoice is null)
            {
                throw new NotFoundException($"Invoice with ID {request.Id} not found.");
            }

            // Update the Invoice's properties
            Invoice.UpdateInvoice(request);

            await _InvoiceRepository.UpdateAsync(Invoice);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<InvoiceDto>(Invoice);
        }
    }
}
