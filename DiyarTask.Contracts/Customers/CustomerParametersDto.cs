namespace DiyarTask.Contracts.Customers;

public sealed class CustomerParametersDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}