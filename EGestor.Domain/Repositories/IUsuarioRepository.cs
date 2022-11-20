using EGestor.Domain.Entities;

namespace EGestor.Domain.Repositories;

public interface IUsuarioRepository
{
    Task<bool> LoginExiste(string login);
    Task Inserir(Usuario usuario);
}
