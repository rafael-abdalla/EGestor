namespace EGestor.Domain.Repositories;

public interface IUsuarioRepository
{
    Task<List<Funcao>> BuscarFuncoes();
    Task<Funcao?> BuscarFuncaoPorId(Guid id);
    Task<Usuario?> BuscarPorLogin(string login);
    Task<bool> LoginExiste(string login);
    Task Inserir(Usuario usuario);
}
