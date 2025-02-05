namespace DiyarTask.Contracts.Customers;

public sealed record CustomerForUpdateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}