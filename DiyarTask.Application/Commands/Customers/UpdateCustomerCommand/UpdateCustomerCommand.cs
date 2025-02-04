using DiyarTask.Domain.Aggregates.CustomerAggregate.Interfaces;
using DiyarTask.Shared.Models.Response.Customer;
using MediatR;

namespace DiyarTask.Application.Commands.Customers.UpdateCustomerCommand
{
    public sealed record UpdateCustomerCommand(
    Guid CustomerId,
    string Name,
    string Email,
    string PhoneNumber
) : IRequest<CustomerDto>, IUpdateCustomerCommand;

}
