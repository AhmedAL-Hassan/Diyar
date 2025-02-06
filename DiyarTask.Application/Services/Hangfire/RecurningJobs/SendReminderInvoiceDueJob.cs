namespace DiyarTask.Application.Services.Hangfire.RecurningJobs;

using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Notification;
using System.Threading.Tasks;

public class SendReminderInvoiceDueJob : ISendReminderInvoiceDueJob
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IEnumerable<INotificationService> _notificationServices;

    public SendReminderInvoiceDueJob(IEnumerable<INotificationService> notificationServices, ICustomerRepository customerRepository)
    {
        _notificationServices = notificationServices;
        _customerRepository = customerRepository;
    }

    public async Task ExecuteAsync()
    {
        var userId = Guid.NewGuid();
        var message = "Your invoice is due!";
        var recipient = "customer@example.com";
        var phoneNumber = "00962780136213";

        var notificationData = new NotificationData(userId, message, recipient, phoneNumber);

        foreach (var notificationService in _notificationServices)
        {
            await notificationService.SendAsync(notificationData);
        }

        Console.WriteLine("Reminder invoice sent to all services.");
    }
}
