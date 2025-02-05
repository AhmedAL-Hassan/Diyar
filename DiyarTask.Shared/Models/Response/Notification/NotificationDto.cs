using DiyarTask.Domain.Aggregates.NotificationAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyarTask.Shared.Models.Response.Notification
{
    public class NotificationDto
    {
        public int NotificationId { get; set; }
        public string CustomerName { get; set; }
        public string Message { get; set; }
        public DateTime SentDateUtc { get; set; }
        public DateTime SentDateLocal { get; set; }
        public SentStatusEnum SentStatus { get; set; }
        public string ErrorMessage { get; set; }
        public string NotificationType { get; set; }// sms, email or web
    }

}
