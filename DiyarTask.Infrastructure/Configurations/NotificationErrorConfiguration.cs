namespace DiyarTask.Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DiyarTask.Domain.Aggregates.NotificationAggregate;

public class NotificationErrorConfiguration : IEntityTypeConfiguration<NotificationError>
{
    public void Configure(EntityTypeBuilder<NotificationError> builder)
    {
        builder.HasKey(ne => ne.Id);

        builder.Property(ne => ne.OccurredOnUTC)
            .IsRequired();

        builder.Property(ne => ne.OccurredOnLocal)
            .IsRequired();

        builder.Property(ne => ne.ErrorMessage)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(ne => ne.Notification)
            .WithMany()
            .HasForeignKey(ne => ne.NotificationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}