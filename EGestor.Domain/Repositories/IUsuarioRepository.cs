using EGestor.Domain.Entities;

namespace EGestor.Domain.Repositories;

public interface IUsuarioRepository
{
    Task<Funcao?> BuscarFuncaoPorId(Guid id);
    Task<Usuario?> BuscarPorLogin(string login);
    Task<bool> LoginExiste(string login);
    Task Inserir(Usuario usuario);
}
