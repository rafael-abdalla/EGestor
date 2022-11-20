using EGestor.Domain.Entities;
using EGestor.Domain.Repositories;
using EGestor.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EGestor.Infra.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EGestorContext _context;
    public UsuarioRepository(EGestorContext context)
    {
        _context = context;
    }

    public async Task<Funcao?> BuscarFuncaoPorId(Guid id)
    {
        return await _context.Funcoes.FindAsync(id);
    }

    public async Task<List<Funcao>> BuscarFuncoes()
    {
        return await _context.Funcoes.AsNoTracking().ToListAsync();
    }

    public async Task<Usuario?> BuscarPorLogin(string login)
    {
        return await _context.Usuario
            .AsNoTracking()
            .Include(x => x.Funcoes)
            .FirstOrDefaultAsync(x => x.Login == login);
    }

    public async Task Inserir(Usuario usuario)
    {
        await _context.Usuario.AddAsync(usuario);
    }

    public async Task<bool> LoginExiste(string login)
    {
        return await _context.Usuario.AsNoTracking().AnyAsync(x => x.Login == login);
    }
}
