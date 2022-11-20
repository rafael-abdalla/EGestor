using EGestor.Domain.Entities;
using EGestor.Domain.Repositories;
using EGestor.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EGestor.Infra.Repositories;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly EGestorContext _context;

    public FuncionarioRepository(EGestorContext context)
    {
        _context = context;
    }

    public async Task<List<Funcionario>> BuscarTodos()
    {
        return await _context.Funcionarios
            .AsNoTracking()
            .Include(x => x.Pessoa)
            .ToListAsync();
    }

    public async Task Inserir(Funcionario funcionario)
    {
        await _context.Funcionarios.AddAsync(funcionario);
    }
}
