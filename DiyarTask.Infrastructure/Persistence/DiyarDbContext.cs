namespace DiyarTask.Infrastructure.Persistence;

using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Aggregates.NotificationAggregate;
using DiyarTask.Domain.Aggregates.Reminder;

using Microsoft.EntityFrameworkCore;

using DiyarTask.Domain.Aggregates.CustomerrAggregate;
using DiyarTask.Infrastructure.Configurations;

public class DiyarDbContext : DbContext
{
    public DiyarDbContext(DbContextOptions<DiyarDbContext> options)
    : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<PaymentError> PaymentErrors { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotificationError> NotificationErrors { get; set; }
    public DbSet<NotificationType> NotificationTypes { get; set; }
    public DbSet<NotificationTemplate> NotificationTemplates { get; set; }
    public DbSet<Reminder> Reminders { get; set; }
    public DbSet<ReminderUser> ReminderUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiyarDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationErrorConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationTemplateConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentErrorConfiguration());
        modelBuilder.ApplyConfiguration(new ReminderConfiguration());
        modelBuilder.ApplyConfiguration(new ReminderUserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}