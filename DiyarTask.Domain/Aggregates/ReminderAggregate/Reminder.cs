namespace DiyarTask.Domain.Aggregates.Reminder;

using DiyarTask.Domain.Aggregates.ReminderAggregate.Interfaces;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Enums;

public class Reminder : BaseEntity<Guid>, IAuditableEntity
{
    public ReminderTimingEnum ReminderTiming { get; set; }
    public ReminderDurationTypeEnum DurationType { get; set; }
    public int DurationInterval { get; set; }
    public ReminderRepeatTypeEnum RepeatType { get; set; }
    public int RepeatCount { get; set; }
    public string CreatedBy { get; private set; }
    public string ModifiedBy { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime? ModifiedDate { get; private set; }
    public List<ReminderUser> ReminderUsers { get; private set; }

    public static Reminder AddReminder(ICreateReminderModel request)
    {
       var reminder = new Reminder
        {
            Id = Guid.NewGuid(),

            ReminderTiming = request.ReminderTiming,
            DurationType = request.DurationType,
            DurationInterval = request.DurationInterval,
            RepeatType = request.RepeatType,
            RepeatCount = request.RepeatCount,
            CreatedDate = DateTime.UtcNow
        };

        if (request.CustomerIds != null) 
        {
            reminder.ReminderUsers = new List<ReminderUser>();

            request.CustomerIds.ForEach(customerId =>
            {
                var reminderUser = new ReminderUser();
                reminderUser.AddCustomer(customerId);
                reminder.ReminderUsers.Add(reminderUser);
            });
        }

        return reminder;
    }

    public void UpdateReminder(IUpdateReminderCommand request)
    {
        ReminderTiming = request.ReminderTiming;
        DurationType = request.DurationType;
        DurationInterval = request.DurationInterval;
        RepeatType = request.RepeatType;
        RepeatCount = request.RepeatCount;
        ModifiedDate = DateTime.UtcNow;
    }
}