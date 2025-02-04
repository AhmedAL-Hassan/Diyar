using DiyarTask.Shared.Models.Response.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyarTask.Application.Queries.Customers.GetCustomerQuery
{
    public sealed class GetCustomerQuery : IRequest<CustomerDto>
    {
        public Guid CustomerId { get; }

        public GetCustomerQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }

}
