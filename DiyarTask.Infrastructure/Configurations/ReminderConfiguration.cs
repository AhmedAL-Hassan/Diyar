namespace DiyarTask.Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DiyarTask.Domain.Aggregates.Reminder;

public class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
{
    public void Configure(EntityTypeBuilder<Reminder> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.ReminderTiming)
            .IsRequired();

        builder.Property(r => r.DurationType)
            .IsRequired();

        builder.Property(r => r.DurationInterval)
            .IsRequired();

        builder.Property(r => r.RepeatType)
            .IsRequired();

        builder.Property(r => r.RepeatCount)
            .IsRequired();

        builder.Property(r => r.CreatedBy)
            .HasMaxLength(100);

        builder.Property(r => r.ModifiedBy)
            .HasMaxLength(100);

        builder.Property(r => r.CreatedDate)
            .IsRequired();

        builder.HasIndex(r => r.CreatedDate);

        builder.Property(r => r.ModifiedDate)
            .IsRequired(false);
    }
}