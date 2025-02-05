namespace DiyarTask.Infrastructure.Persistence.Repositories;

using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Domain.Common.Interfaces.Persistence;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(DiyarDbContext context)
        : base(context)
    {
    }
}