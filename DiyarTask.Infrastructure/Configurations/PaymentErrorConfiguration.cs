namespace DiyarTask.Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DiyarTask.Domain.Aggregates.InvoiceAggregate;

public class PaymentErrorConfiguration : IEntityTypeConfiguration<PaymentError>
{
    public void Configure(EntityTypeBuilder<PaymentError> builder)
    {
        builder.HasKey(pe => pe.Id);

        builder.Property(pe => pe.OccurredOnUTC)
            .IsRequired();

        builder.Property(pe => pe.OccurredOnLocal)
            .IsRequired();

        builder.Property(pe => pe.ErrorMessage)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(pe => pe.Invoice)
            .WithMany()
            .HasForeignKey(pe => pe.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}