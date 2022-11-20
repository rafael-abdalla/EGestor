namespace EGestor.Domain.Repositories;

public interface IFuncionarioRepository
{
    Task<List<Funcionario>> BuscarTodos();
    Task Inserir(Funcionario funcionario);
}
