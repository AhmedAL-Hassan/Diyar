namespace DiyarTask.Application.Services.Hangfire.RecurningJobs;

using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Notification;
using System.Threading.Tasks;

public sealed class SendReminderInvoiceDueJob : ISendReminderInvoiceDueJob
{
    private const int _batchSize = 500;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IEnumerable<INotificationService> _notificationServices;

    public SendReminderInvoiceDueJob(
        IEnumerable<INotificationService> notificationServices,
        ICustomerRepository customerRepository,
        IMapper mapper)
    {
        _notificationServices = notificationServices;
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task ExecuteAsync()
    {

        var isThereMoreUsers = true;
        DateTime? lastDateTime = null;
        do
        {
            var customers = await _customerRepository.GetCustomersToRemindAsync(_batchSize, lastDateTime);
            
            foreach (var customer in customers) 
            {
                var notificationData = _mapper.Map<NotificationData>(customer);
                foreach (var notificationService in _notificationServices)
                {
                    await notificationService.SendAsync(notificationData);
                }
            }

            lastDateTime = customers.LastOrDefault()?.InvocieCreatedDate;

            isThereMoreUsers = customers.Count == _batchSize;

        } while (isThereMoreUsers);
    }
}
