using EGestor.Shared.Entities;

namespace EGestor.Domain.Entities;

public class Cliente : Entity
{
    public Cliente(Guid pessoaId, decimal limiteCredito, string? observacao)
    {
        PessoaId = pessoaId;
        LimiteCredito = limiteCredito;
        Observacao = observacao;
        Ativo = true;
    }

    public Guid PessoaId { get; private set; }
    public decimal LimiteCredito { get; private set; }
    public string? Observacao { get; set; }
    public bool Ativo { get; private set; }

    public virtual Pessoa Pessoa { get; set; } = null!;
}
