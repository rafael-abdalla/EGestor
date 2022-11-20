using EGestor.Shared.Entities;

namespace EGestor.Domain.Entities;

public class Funcionario : Entity
{
    public Funcionario(Guid pessoaId, DateTime? dataAdmissao, string? observacao)
    {
        PessoaId = pessoaId;
        DataAdmissao = dataAdmissao;
        Observacao = observacao;
    }

    public Guid PessoaId { get; private set; }
    public DateTime? DataAdmissao { get; private set; }
    public string? Observacao { get; private set; }

    public virtual Pessoa Pessoa { get; set; } = null!;
    public virtual ICollection<Usuario> Usuarios { get; set; } = null!;

}
