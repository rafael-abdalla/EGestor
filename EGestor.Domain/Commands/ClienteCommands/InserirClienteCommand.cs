namespace EGestor.Domain.Commands;

public class InserirClienteCommand : Notifiable, ICommand
{
    public InserirClienteCommand(string nome, string apelido, string documento, string telefone, string email, decimal limiteCredito, string? observacao)
    {
        Nome = nome;
        Apelido = apelido;
        Documento = documento;
        Telefone = telefone;
        Email = email;
        LimiteCredito = limiteCredito;
        Observacao = observacao;
    }

    public string Nome { get; set; }
    public string Apelido { get; set; }
    public string Documento { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public decimal LimiteCredito { get; set; }
    public string? Observacao { get; set; }

    public bool IsValid()
    {
        return true;
    }
}
