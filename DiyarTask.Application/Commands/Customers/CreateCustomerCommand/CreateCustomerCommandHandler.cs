namespace DiyarTask.Application.Commands.Customers.CreateCustomerCommand;

using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Shared.Models.Response.Customer;

using MapsterMapper;

using MediatR;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.AddCustomer(request);

        await _customerRepository.AddAsync(customer);
        await _customerRepository.SaveChangesAsync();

        return _mapper.Map<CustomerResponse>(customer);
    }
}