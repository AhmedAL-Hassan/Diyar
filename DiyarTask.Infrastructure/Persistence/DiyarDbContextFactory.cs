namespace DiyarTask.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System.IO;

public class DiyarDbContextFactory : IDesignTimeDbContextFactory<DiyarDbContext>
{
    public DiyarDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "DiyarTask.Api"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<DiyarDbContext>();

        optionsBuilder.UseSqlServer(connectionString);

        return new DiyarDbContext(optionsBuilder.Options);
    }
}