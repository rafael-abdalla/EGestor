using EGestor.Shared.Entities;

namespace EGestor.Domain.Entities;

public class Funcao : Entity
{
    public string Descricao { get; private set; }

    public Funcao(string descricao)
    {
        Descricao = descricao;
    }

    public virtual ICollection<Usuario> Usuarios { get; set; } = null!;
}
