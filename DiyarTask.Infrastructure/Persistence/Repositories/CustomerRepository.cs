namespace DiyarTask.Infrastructure.Persistence.Repositories;

using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Shared.Enums;
using DiyarTask.Shared.Models.Response.Reminder;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    private readonly DiyarDbContext _context;
    public CustomerRepository(DiyarDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<List<CustomerReminderModel>> GetCustomersToRemindAsync(int batchSize, DateTime? lastDateTime = null)
    {
        var data = await (from c in _context.Customers
                           join i in _context.Invoices on c.Id equals i.CustomerId
                           join ru in _context.ReminderUsers on c.Id equals ru.CustomerId
                           join r in _context.Reminders on ru.ReminderId equals r.Id
                           where (lastDateTime == null || i.CreatedDate >= lastDateTime) && i.PaymentStatus != Domain.Aggregates.InvoiceAggregate.PaymentStatusEnum.Paid
                           orderby i.CreatedDate
                           select new { c, i, r })
                     .AsSplitQuery()
                     .Take(batchSize)
                     .ToListAsync();

        var users = data
                     .Where(x => IsReminderToday(x.i.DueDate, x.r.ReminderTiming, x.r.DurationType, x.r.DurationInterval, x.r.RepeatType, x.r.RepeatCount))
                     .Select(x => new CustomerReminderModel
                     { 
                       UserId = x.c.Id,
                       UserEmail = x.c.Email,
                       UserPhoneNumber = x.c.PhoneNumber,
                       InvoiceAmount = x.i.Amount,
                       InvocieCreatedDate = x.i.CreatedDate
                     })
                     .ToList();

        return users;
    }

    private bool IsReminderToday(DateTime dueDate, ReminderTimingEnum reminderTiming, ReminderDurationTypeEnum durationType,
                                   int durationInterval, ReminderRepeatTypeEnum repeatType, int repeatCount)
    {
        DateTime today = DateTime.UtcNow.Date;

        DateTime reminderDate = reminderTiming switch
        {
            ReminderTimingEnum.Before => dueDate - GetTimeSpan(durationType, durationInterval),
            ReminderTimingEnum.After => dueDate + GetTimeSpan(durationType, durationInterval),
            _ => dueDate
        };

        if (today.Date > reminderDate.Date)
        {
            return false;
        }
        else if (today.Date == reminderDate.Date)
        {
            return true;
        }

        if (repeatType == ReminderRepeatTypeEnum.None || repeatCount == 0)
        {
            return false;
        }

        if (repeatCount == -1) // infinite reminder
        {
            return repeatType switch
            {
                ReminderRepeatTypeEnum.Daily => true,
                ReminderRepeatTypeEnum.Weekly => (today.Date - reminderDate.Date).Days % 7 == 0,
                ReminderRepeatTypeEnum.Monthly => (today.Date - reminderDate.Date).Days % 30 == 0,
                _ => false
            };
        }
        else // specific count for repeating
        {
            return repeatType switch
            {
                ReminderRepeatTypeEnum.Daily => true,
                ReminderRepeatTypeEnum.Weekly => (today.Date - reminderDate.Date).Days % 7 <= repeatCount,
                ReminderRepeatTypeEnum.Monthly => (today.Date - reminderDate.Date).Days % 30 <= repeatCount,
                _ => false
            };
        }
    }

    private TimeSpan GetTimeSpan(ReminderDurationTypeEnum durationType, int interval)
    {
        return durationType switch
        {
            ReminderDurationTypeEnum.Days => TimeSpan.FromDays(interval),
            ReminderDurationTypeEnum.Weeks => TimeSpan.FromDays(interval * 7),
            ReminderDurationTypeEnum.Months => TimeSpan.FromDays(interval * 30),  // Approximate months
            _ => TimeSpan.Zero
        };
    }
}