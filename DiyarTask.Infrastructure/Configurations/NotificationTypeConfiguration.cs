using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DiyarTask.Domain.Aggregates.NotificationAggregate;

public class NotificationTypeConfiguration : IEntityTypeConfiguration<NotificationType>
{
    public void Configure(EntityTypeBuilder<NotificationType> builder)
    {
        builder.HasKey(nt => nt.Id);

        builder.Property(nt => nt.TypeName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(nt => nt.Description)
            .HasMaxLength(500);

        builder.HasMany(nt => nt.NotificationTemplates)
            .WithOne()
            .HasForeignKey(nt => nt.NotificationTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}