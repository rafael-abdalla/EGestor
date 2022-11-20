namespace EGestor.Domain.Queries;

public class ClienteProcura
{
    public ClienteProcura(Guid id, string nome, string apelido, string email, bool ativo)
    {
        Id = id;
        Nome = nome;
        Apelido = apelido;
        Email = email;
        Ativo = ativo;
    }

    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Apelido { get; set; }
    public string Email { get; set; }
    public bool Ativo { get; set; }
}
