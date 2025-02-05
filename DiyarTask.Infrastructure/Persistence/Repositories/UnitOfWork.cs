namespace DiyarTask.Infrastructure.Persistence.Repositories;

using DiyarTask.Domain.Core;

public class UnitOfWork : IUnitOfWork
{
    private readonly DiyarDbContext _context;

    public UnitOfWork(DiyarDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}