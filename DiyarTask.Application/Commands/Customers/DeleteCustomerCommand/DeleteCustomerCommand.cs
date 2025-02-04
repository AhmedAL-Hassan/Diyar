using MediatR;

namespace DiyarTask.Application.Commands.Customers.DeleteCustomerCommand
{
    public sealed record DeleteCustomerCommand(Guid CustomerId) : IRequest<bool>;
}
