namespace DiyarTask.Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DiyarTask.Domain.Aggregates.Reminder;

public class ReminderUserConfiguration : IEntityTypeConfiguration<ReminderUser>
{
    public void Configure(EntityTypeBuilder<ReminderUser> builder)
    {
        builder.HasKey(ru => ru.Id);

        builder.Property(ru => ru.ReminderId)
            .IsRequired();

        builder.Property(ru => ru.CustomerId)
            .IsRequired();

        builder.HasOne(ru => ru.Reminder)
            .WithMany(r => r.ReminderUsers)
            .HasForeignKey(ru => ru.ReminderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ru => ru.Customer)
            .WithMany()
            .HasForeignKey(ru => ru.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}