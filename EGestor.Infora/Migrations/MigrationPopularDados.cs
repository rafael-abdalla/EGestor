using EGestor.Domain.Core.Identity;
using EGestor.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EGestor.Infra.Migrations;

public class MigrationPopularDados
{
    public static void Executar(ref MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData("Pessoa", new string[] { "Id", "Nome", "Apelido", "Documento", "Telefone", "Email" }, new object[] { Guid.Parse("6e187c1d-cc05-43a7-be6e-c44704126ef9"), "SISTEMA", "SISTEMA", "00000000000", "00000000000", "contato@suporte.com" });
        migrationBuilder.InsertData("Funcionario", new string[] { "Id", "PessoaId" }, new object[] { Guid.Parse("2721647e-198f-42dc-bac6-da981cdcf4ef"), Guid.Parse("6e187c1d-cc05-43a7-be6e-c44704126ef9") });

        var usuario = new Usuario("sistema", "123456", Guid.Parse("2721647e-198f-42dc-bac6-da981cdcf4ef"));
        usuario.setSenha(Hasher.gerarHash(usuario));

        migrationBuilder.InsertData("Usuario", new string[] { "Id", "Login", "Senha", "FuncionarioId" }, new object[] { usuario.Id, usuario.Login, usuario.Senha, usuario.FuncionarioId });
        migrationBuilder.InsertData("FuncaoUsuario", new string[] { "FuncoesId", "UsuariosId" }, new object[] { Guid.Parse("3847181b-2014-43df-a92b-1d4644871757"), usuario.Id });
    }
}