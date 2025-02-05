namespace DiyarTask.Domain.Aggregates.CustomerAggregate.Interfaces;

public interface IUpdateCustomerCommand
{
    Guid Id { get; }
    string Name { get; }
    string Email { get; }
    string PhoneNumber { get; }
}