using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DiyarTask.Domain.Aggregates.NotificationAggregate;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(nt => nt.Id);

        builder.Property(r => r.SentDateUtc)
            .IsRequired();

        builder.HasIndex(r => r.SentDateUtc);
    }
}