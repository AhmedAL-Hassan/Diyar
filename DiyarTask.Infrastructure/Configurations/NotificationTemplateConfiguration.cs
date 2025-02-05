namespace DiyarTask.Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DiyarTask.Domain.Aggregates.NotificationAggregate;

public class NotificationTemplateConfiguration : IEntityTypeConfiguration<NotificationTemplate>
{
    public void Configure(EntityTypeBuilder<NotificationTemplate> builder)
    {
        builder.HasKey(nt => nt.Id);

        builder.Property(nt => nt.TemplateName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(nt => nt.TemplateContent)
            .IsRequired()
            .HasMaxLength(2000);

        builder.HasOne(nt => nt.NotificationType)
            .WithMany()
            .HasForeignKey(nt => nt.NotificationTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(nt => nt.Notifications)
            .WithOne()
            .HasForeignKey(n => n.NotificationTemplateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}