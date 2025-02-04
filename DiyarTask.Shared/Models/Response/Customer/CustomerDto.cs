namespace DiyarTask.Shared.Models.Response.Customer;

public sealed record CustomerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }

}
