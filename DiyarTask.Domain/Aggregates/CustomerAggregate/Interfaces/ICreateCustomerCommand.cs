namespace DiyarTask.Domain.Aggregates.CustomerAggregate.Interfaces
{
    public interface ICreateCustomerCommand
    {
        string Name { get; }
        string Email { get; }
        string PhoneNumber { get; }
    }

}
