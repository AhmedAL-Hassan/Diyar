﻿namespace DiyarTask.Shared.Models.Notification
{
    public class NotificationData
    {
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public decimal InvoiceAmount { get; set; }
        public DateTime InvocieCreatedDate { get; set; }
        public string Message { get; set; }
    }

}
