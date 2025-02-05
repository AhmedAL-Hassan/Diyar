namespace DiyarTask.Application.Queries.Invoices.GetInvoiceQuery;

using DiyarTask.Application.Queries.Customers.GetCustomerQuery;
using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Shared.Core.Errors;
using DiyarTask.Shared.Models.Response.Customer;

using MapsterMapper;

using MediatR;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
        if (customer == null)
        {
            throw new NotFoundException($"Customer with ID {request.CustomerId} not found.");
        }

        return _mapper.Map<CustomerResponse>(customer);
    }
}