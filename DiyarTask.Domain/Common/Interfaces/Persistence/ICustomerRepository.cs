namespace DiyarTask.Domain.Common.Interfaces.Persistence;

using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Domain.Core;

public interface ICustomerRepository : IRepository<Customer>
{
}