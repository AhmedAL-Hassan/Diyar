namespace DiyarTask.Contracts.Reminders;

using Destructurama.Attributed;

public sealed record ReminderForCreationDto
{
    public int DurationInterval { get; set; }
    public int RepeatCount { get; set; }

}
