using DiyarTask.Application.DI;
using DiyarTask.Infrastructure.DI;

using Mapster;

var builder = WebApplication.CreateBuilder(args);

AddAppServices(builder.Services, builder.Configuration);
ConfigureAutoMapper(builder.Services);
ConfigureAddApiVersioning(builder.Services);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = ApiVersion.Default;
    });
}