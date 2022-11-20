using EGestor.Domain.Repositories;
using EGestor.Infra.Contexts;

namespace EGestor.Infra.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly EGestorContext _context;
    public UnitOfWork(EGestorContext context)
    {
        _context = context;
    }

    public async Task BeginTransaction()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task<bool> Commit()
    {
        var rowAffected = await _context.SaveChangesAsync();
        if (HasOpenTransaction()) await _context.Database.CurrentTransaction!.CommitAsync();
        return rowAffected > 0;
    }

    public bool HasOpenTransaction()
    {
        return _context.Database.CurrentTransaction != null;
    }

    public async Task Rollback()
    {
        if (HasOpenTransaction()) await _context.Database.CurrentTransaction!.RollbackAsync();
    }
}
