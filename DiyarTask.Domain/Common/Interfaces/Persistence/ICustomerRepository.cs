namespace DiyarTask.Domain.Common.Interfaces.Persistence;

using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Response.Reminder;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<List<CustomerReminderModel>> GetCustomersToRemindAsync(int batchSize, DateTime? lastDateTime = null);
}