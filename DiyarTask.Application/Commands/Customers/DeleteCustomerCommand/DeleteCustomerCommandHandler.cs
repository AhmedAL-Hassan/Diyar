using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Core.Errors;
using MediatR;

namespace DiyarTask.Application.Commands.Customers.DeleteCustomerCommand
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer is null)
            {
                throw new NotFoundException($"Customer with ID {request.CustomerId} not found.");
            }

            await _customerRepository.DeleteAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
