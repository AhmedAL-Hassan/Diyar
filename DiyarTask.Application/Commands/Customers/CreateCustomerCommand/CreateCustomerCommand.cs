namespace DiyarTask.Application.Commands.Customers.CreateCustomerCommand;

using DiyarTask.Domain.Aggregates.CustomerAggregate.Interfaces;
using DiyarTask.Shared.Models.Response.Customer;
using MediatR;

public sealed class CreateCustomerCommand : IRequest<CustomerDto>, ICreateCustomerCommand
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }   
}
