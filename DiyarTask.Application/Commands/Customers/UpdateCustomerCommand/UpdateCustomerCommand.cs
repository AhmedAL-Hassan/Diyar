namespace DiyarTask.Application.Commands.Customers.UpdateCustomerCommand;

using DiyarTask.Domain.Aggregates.CustomerAggregate.Interfaces;
using DiyarTask.Shared.Models.Response.Customer;
using MediatR;

public sealed record UpdateCustomerCommand(Guid CustomerId, string Name, string Email, string PhoneNumber) : IRequest<CustomerResponse>, IUpdateCustomerCommand;