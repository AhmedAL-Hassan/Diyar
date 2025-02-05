namespace DiyarTask.Contracts.Customers.Request;

public sealed record CreateCustomerRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}