using Microsoft.AspNetCore.Identity;

namespace EGestor.Domain.Core.Identity;

public static class Hasher
{
    public static string gerarHash(Usuario usuario)
    {
        var passwordHasher = new PasswordHasher<Usuario>();
        return passwordHasher.HashPassword(usuario, usuario.Senha);
    }
}
