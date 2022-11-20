namespace EGestor.Domain.Repositories;

public interface IUnitOfWork
{
    bool HasOpenTransaction();
    Task BeginTransaction();
    Task<bool> Commit();
    Task Rollback();
}
