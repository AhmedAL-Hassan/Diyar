namespace DiyarTask.Application.Commands.Customers.UpdateCustomerCommand;

using DiyarTask.Domain.Aggregates.CustomerAggregate.Interfaces;
using DiyarTask.Shared.Models.Response.Customer;

public sealed record UpdateCustomerCommand(Guid Id, string Name, string Email, string PhoneNumber) : IRequest<CustomerResponse>, IUpdateCustomerCommand;