using EGestor.Shared.Entities;
using FluentValidator.Validation;

namespace EGestor.Domain.Entities;

public class Pessoa : Entity
{
    public Pessoa(Guid id, string nome, string apelido, string documento, string telefone, string email)
    {
        Id = id;
        Nome = nome;
        Apelido = apelido;
        Documento = documento;
        Telefone = telefone;
        Email = email;
    }

    public Pessoa(string nome, string apelido, string documento, string telefone, string email)
    {
        Nome = nome;
        Apelido = apelido;
        Documento = documento;
        Telefone = telefone;
        Email = email;

        AddNotifications(new ValidationContract()
            .Requires()
            .HasMinLen(Nome, 3, "Nome", "O nome deve conter pelo menos 3 caracteres")
            .HasMaxLen(Nome, 100, "Nome", "O nome deve conter no máximo 100 caracteres")
            .HasMinLen(Apelido, 3, "Apelido", "O apelido deve conter pelo menos 3 caracteres")
            .HasMaxLen(Apelido, 100, "Apelido", "O apelido deve conter no máximo 100 caracteres")
            .IsEmail(Email, "Email", "E-mail é inválido")
        );
    }

    public string Nome { get; private set; }
    public string Apelido { get; private set; }
    public string Documento { get; private set; }
    public string Telefone { get; private set; }
    public string Email { get; private set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = null!;
    public virtual ICollection<Funcionario> Funcionarios { get; set; } = null!;
}
