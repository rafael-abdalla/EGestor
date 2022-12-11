namespace EGestor.Domain.Queries;

public class ClienteProcuraRetorno
{
    public ClienteProcuraRetorno(Guid id, Guid pessoaId, string documento, string nome, string email, decimal limiteCredito, bool ativo)
    {
        Id = id;
        PessoaId = pessoaId;
        Documento = documento;
        Nome = nome;
        Email = email;
        LimiteCredito = limiteCredito;
        Ativo = ativo;
    }

    public Guid Id { get; set; }
    public Guid PessoaId { get; set; }
    public string Documento { get; set; }
    public string Nome { get; set; }    
    public string Email { get; set; }
    public decimal LimiteCredito { get; set; }
    public bool Ativo { get; set; }
}
