namespace EGestor.Domain.Services;

public interface IJwtService
{
    string obterJwt(Usuario usuario);
}
