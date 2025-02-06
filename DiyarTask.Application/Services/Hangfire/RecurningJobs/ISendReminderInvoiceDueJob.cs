namespace DiyarTask.Application.Services.Hangfire.RecurningJobs;
using System.Threading.Tasks;

public interface ISendReminderInvoiceDueJob
{
    Task ExecuteAsync();
}
