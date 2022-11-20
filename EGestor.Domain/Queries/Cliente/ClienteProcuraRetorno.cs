namespace EGestor.Domain.Queries;

public class ClienteProcuraRetorno
{
    public ClienteProcuraRetorno(Guid id, Guid pessoaId, string nome, string apelido, string email, bool ativo)
    {
        Id = id;
        PessoaId = pessoaId;
        Nome = nome;
        Apelido = apelido;
        Email = email;
        Ativo = ativo;
    }

    public Guid Id { get; set; }
    public Guid PessoaId { get; set; }
    public string Nome { get; set; }
    public string Apelido { get; set; }
    public string Email { get; set; }
    public bool Ativo { get; set; }
}
