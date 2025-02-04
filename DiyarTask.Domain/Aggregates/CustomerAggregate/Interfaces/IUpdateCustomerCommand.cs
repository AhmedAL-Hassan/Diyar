namespace DiyarTask.Domain.Aggregates.CustomerAggregate.Interfaces
{
    public interface IUpdateCustomerCommand
    {
        Guid CustomerId { get; }
        string Name { get; }
        string Email { get; }
        string PhoneNumber { get; }
    }
}
