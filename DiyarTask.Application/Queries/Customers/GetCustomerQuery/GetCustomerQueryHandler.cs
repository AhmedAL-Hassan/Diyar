namespace DiyarTask.Application.Queries.Customers.GetCustomerQuery;

using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Shared.Core.Errors;
using DiyarTask.Shared.Models.Response.Customer;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerResponse>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<CustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);
        if (customer == null)
        {
            throw new NotFoundException($"Customer with ID {request.Id} not found.");
        }

        return _mapper.Map<CustomerResponse>(customer);
    }
}