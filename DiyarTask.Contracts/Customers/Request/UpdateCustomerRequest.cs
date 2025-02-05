namespace DiyarTask.Contracts.Customers.Request;

public sealed record UpdateCustomerRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}