namespace DiyarTask.Shared.Models.Notification
{
    public class NotificationData
    {
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public string Recipient { get; set; }
        public string PhoneNumber { get; set; }

        // Constructor to initialize the properties
        public NotificationData(Guid userId, string message, string recipient, string phoneNumber)
        {
            UserId = userId;
            Message = message;
            Recipient = recipient;
            PhoneNumber = phoneNumber;
        }
    }

}
