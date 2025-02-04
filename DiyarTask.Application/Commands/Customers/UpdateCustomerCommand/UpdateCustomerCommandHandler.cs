using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Core.Errors;
using DiyarTask.Shared.Models.Response.Customer;
using MapsterMapper;
using MediatR;

namespace DiyarTask.Application.Commands.Customers.UpdateCustomerCommand
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            // Fetch the existing customer from the database
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer is null)
            {
                throw new NotFoundException($"Customer with ID {request.CustomerId} not found.");
            }

            // Update the customer's properties
            customer.Update(request);

            await _customerRepository.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
