using EGestor.Domain.Entities;

namespace EGestor.Domain.Services;

public interface IJwtService
{
    string obterJwt(Usuario usuario);
}
