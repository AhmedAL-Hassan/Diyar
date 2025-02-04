namespace DiyarTask.Infrastructure.Persistence;

using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Aggregates.NotificationAggregate;
using DiyarTask.Domain.Aggregates.Reminder;

using Microsoft.EntityFrameworkCore;

using DiyarTask.Domain.Aggregates.CustomerrAggregate;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<PaymentError> PaymentErrors { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotificationError> NotificationErrors { get; set; }
    public DbSet<NotificationType> NotificationTypes { get; set; }
    public DbSet<NotificationTemplate> NotificationTemplates { get; set; }
    public DbSet<Reminder> Reminders { get; set; }
    public DbSet<ReminderUser> ReminderUsers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Automatically apply all configurations in the assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}