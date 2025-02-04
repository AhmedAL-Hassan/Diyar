using DiyarTask.Api.Mapping;
using DiyarTask.Application;
using DiyarTask.Domain.Core.Configs;
using DiyarTask.Infrastructure;
using Mapster;
using MapsterMapper;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddMapster();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddPersistance(builder.Configuration);
}

var app = builder.Build();
{
    //Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseExceptionHandler("/Error");
    }

    app.MapControllers();
    app.UseHttpsRedirection();

    app.Run();
}