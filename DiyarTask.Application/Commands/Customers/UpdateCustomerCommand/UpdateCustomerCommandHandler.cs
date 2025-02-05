namespace DiyarTask.Application.Commands.Customers.UpdateCustomerCommand;

using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Shared.Core.Errors;
using DiyarTask.Shared.Models.Response.Customer;

using MapsterMapper;

using MediatR;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
        if (customer is null)
        {
            throw new NotFoundException($"Customer with ID {request.CustomerId} not found.");
        }

        customer.Update(request);

        await _customerRepository.UpdateAsync(customer);
        await _customerRepository.SaveChangesAsync();

        return _mapper.Map<CustomerResponse>(customer);
    }
}