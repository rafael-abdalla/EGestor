namespace EGestor.Domain.Commands;

public class InserirFuncionarioCommand : ICommand
{
    public InserirFuncionarioCommand(string nome, string apelido, string documento, string telefone, string email, DateTime? dataAdmissao, string? observacao)
    {
        Nome = nome;
        Apelido = apelido;
        Documento = documento;
        Telefone = telefone;
        Email = email;
        DataAdmissao = dataAdmissao;
        Observacao = observacao;
    }

    public string Nome { get; set; }
    public string Apelido { get; set; }
    public string Documento { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public DateTime? DataAdmissao { get; set; }
    public string? Observacao { get; set; }

    public bool IsValid()
    {
        return true;
    }
}
