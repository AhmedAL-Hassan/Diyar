namespace DiyarTask.Application.Commands.Customers.CreateCustomerCommand;

using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Response.Customer;
using MapsterMapper;
using MediatR;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        // Map command to entity
        var customer = Customer.AddCustomer(request);

        // Save to database
        await _customerRepository.AddAsync(customer);
        await _unitOfWork.SaveChangesAsync();

        // Return mapped DTO
        return _mapper.Map<CustomerDto>(customer);
    }
}
