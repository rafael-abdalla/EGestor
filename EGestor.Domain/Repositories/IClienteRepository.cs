using EGestor.Domain.Entities;

namespace EGestor.Domain.Repositories;

public interface IClienteRepository
{
    Task<Cliente> BuscarPorId(Guid id);
    Task<bool> DocumentoExiste(string documento);
    Task<List<Cliente>> BuscarTodos();
    Task Inserir(Cliente cliente);

}
