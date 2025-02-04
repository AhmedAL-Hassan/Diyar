using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Shared.Models.Response.Customer;
using MediatR;
using System.Linq.Expressions;

namespace DiyarTask.Application.Queries.GetFilteredCustomersQuery
{
    public sealed class GetFilteredCustomersQuery : BaseQuery<Customer>, IRequest<List<CustomerDto>>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public Expression<Func<Customer, bool>> BuildExpression()
        {
            Expression<Func<Customer, bool>> filter = c => true; // Start with a default "always true" condition

            if (!string.IsNullOrEmpty(Name))
                filter = CombineExpressions(filter, c => c.Name.Contains(Name));

            if (!string.IsNullOrEmpty(Email))
                filter = CombineExpressions(filter, c => c.Email.Contains(Email));

            if (!string.IsNullOrEmpty(PhoneNumber))
                filter = CombineExpressions(filter, c => c.PhoneNumber.Contains(PhoneNumber));

            return filter;
        }
    }
}