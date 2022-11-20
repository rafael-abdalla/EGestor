using EGestor.Domain.Entities;
using EGestor.Domain.Repositories;
using EGestor.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EGestor.Infra.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly EGestorContext _context;
    public ClienteRepository(EGestorContext context)
    {
        _context = context;
    }

    public async Task<bool> DocumentoExiste(string documento)
    {
        return await _context.Clientes
           .AsNoTracking()
           .Include(x => x.Pessoa)
           .AnyAsync(x => x.Pessoa.Documento == documento);
    }

    public async Task<Cliente> BuscarPorId(Guid id)
    {
        return await _context.Clientes
            .AsNoTracking()
            .Include(x => x.Pessoa)
            .FirstAsync(x => x.Id == id);
    }

    public async Task<List<Cliente>> BuscarTodos()
    {
        return await _context.Clientes
            .AsNoTracking()
            .Include(x => x.Pessoa)
            .ToListAsync();
    }

    public async Task Inserir(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
    }
}
