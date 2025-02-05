namespace DiyarTask.Application.Commands.Customers.DeleteCustomerCommand;

using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Shared.Core.Errors;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
        if (customer is null)
        {
            throw new NotFoundException($"Customer with ID {request.CustomerId} not found.");
        }

        await _customerRepository.DeleteAsync(customer);
        await _customerRepository.SaveChangesAsync();

        return true;
    }
}