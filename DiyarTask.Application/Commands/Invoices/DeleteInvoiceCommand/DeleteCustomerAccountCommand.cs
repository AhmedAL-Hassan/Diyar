using MediatR;

namespace DiyarTask.Application.Commands.Customers.DeleteCustomerCommand
{
    public sealed record DeleteCustomerAccountCommand(Guid CustomerId) : IRequest<bool>;
}
