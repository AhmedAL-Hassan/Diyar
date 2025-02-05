namespace DiyarTask.Application.Commands.Customers.DeleteCustomerCommand;

using MediatR;

public sealed record DeleteCustomerCommand(Guid CustomerId) : IRequest<bool>
{
}