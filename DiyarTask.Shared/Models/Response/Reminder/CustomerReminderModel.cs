namespace DiyarTask.Shared.Models.Response.Reminder
{
    public class CustomerReminderModel
    {
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public decimal InvoiceAmount { get; set; }
        public DateTime InvocieCreatedDate { get; set; }
    }
}
