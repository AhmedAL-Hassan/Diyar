using Asp.Versioning;
using DiyarTask.Application.DI;
using DiyarTask.Application.Services.Hangfire.RecurningJobs;
using DiyarTask.Infrastructure.DI;
using Hangfire;
using Mapster;

var builder = WebApplication.CreateBuilder(args);
var hangfireConfig = builder.Configuration.GetSection("Hangfire");

AddAppServices(builder.Services, builder.Configuration);
ConfigureAutoMapper(builder.Services);
ConfigureAddApiVersioning(builder.Services);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHangfireDashboard();

AddRecurningJobs(hangfireConfig);

app.UseHangfireDashboard();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

static void AddAppServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddInfrastructureServices(configuration);
    services.AddApplicationServices();
}

static void ConfigureAutoMapper(IServiceCollection services)
{
    services.AddMapster();
}

static void ConfigureAddApiVersioning(IServiceCollection services)
{
    services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
    });
}

static void AddRecurningJobs(IConfigurationSection hangfireConfig)
{
    var jobId = hangfireConfig["JobId"];
    var scheduleTime = hangfireConfig["ScheduleTime"];

    RecurringJob.AddOrUpdate<ISendReminderInvoiceDueJob>(
        jobId, job => job.ExecuteAsync(), Cron.Daily(int.Parse(scheduleTime.Split(':')[0]), int.Parse(scheduleTime.Split(':')[1]))
    );
}