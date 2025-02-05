namespace DiyarTask.Application.Queries.Customers.GetCustomerQuery;

using DiyarTask.Shared.Models.Response.Customer;

using MediatR;

public sealed class GetCustomerQuery : IRequest<CustomerResponse>
{
    public GetCustomerQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}