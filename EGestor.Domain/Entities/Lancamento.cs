namespace EGestor.Domain.Entities;

public class Lancamento
{
    public Lancamento(Guid usuarioId)
    {
        Id = Guid.NewGuid();
        UsuarioId = usuarioId;
        Criacao = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public Guid UsuarioId { get; private set; }
    public DateTime Criacao { get; private set; }

    public virtual Usuario Usuario { get; set; } = null!;
    public virtual ICollection<Lancamento> Lancamentos { get; set; } = null!;
}
