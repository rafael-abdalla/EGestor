namespace EGestor.Domain.Entities;

public class Lancamento
{
    public Lancamento(Guid id, Guid usuarioId)
    {
        Id = id;
        UsuarioId = usuarioId;
        Criacao = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public Guid UsuarioId { get; private set; }
    public DateTime Criacao { get; private set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
