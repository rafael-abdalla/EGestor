using EGestor.Domain.Entities;
using EGestor.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EGestor.Shared.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string obterJwt(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var chave = Encoding.ASCII.GetBytes(_configuration.GetSection("JWT:Secret").Value!);
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Login)
            };
        claims.AddRange(usuario.Funcoes.Select(x => new Claim(ClaimTypes.Role, x.Descricao)));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Audience = _configuration.GetSection("JWT:Audience").Value,
            Issuer = _configuration.GetSection("JWT:Issuer").Value,
            Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration.GetSection("JWT:ExpiraEmMinutos").Value)),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha512Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
