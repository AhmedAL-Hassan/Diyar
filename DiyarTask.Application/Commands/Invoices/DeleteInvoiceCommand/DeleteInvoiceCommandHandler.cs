using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Core.Errors;
using MediatR;

namespace DiyarTask.Application.Commands.Invoices.DeleteInvoiceCommand
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, bool>
    {
        private readonly IRepository<Invoice> _InvoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteInvoiceCommandHandler(IRepository<Invoice> InvoiceRepository, IUnitOfWork unitOfWork)
        {
            _InvoiceRepository = InvoiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var Invoice = await _InvoiceRepository.GetByIdAsync(request.InvoiceId);
            if (Invoice is null)
            {
                throw new NotFoundException($"Invoice with ID {request.InvoiceId} not found.");
            }

            await _InvoiceRepository.DeleteAsync(Invoice);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
