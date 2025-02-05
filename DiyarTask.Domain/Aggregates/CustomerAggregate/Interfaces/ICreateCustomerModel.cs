namespace DiyarTask.Domain.Aggregates.CustomerAggregate.Interfaces
{
    public interface ICreateCustomerModel
    {
        string Name { get; }
        string Email { get; }
        string PhoneNumber { get; }
    }

}
