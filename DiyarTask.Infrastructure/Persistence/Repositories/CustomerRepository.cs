using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Domain.Core;

namespace DiyarTask.Infrastructure.Persistence.Repositories;

internal class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    {
    }
}
