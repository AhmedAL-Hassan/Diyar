namespace DiyarTask.Shared.Models.Response.Reminder;

public sealed record ReminderDto
{
    public Guid Id { get; set; }
    public int DurationInterval { get; set; }
    public int RepeatCount { get; set; }

}
