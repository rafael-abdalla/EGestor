using EGestor.Domain.Repositories;
using EGestor.Domain.Services;
using EGestor.Infra.Contexts;
using EGestor.Infra.Repositories;
using EGestor.Shared.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EGestor.Api.Extensions;

public static class DependencyRegisterExtension
{
    public static void AddDependencies(this IServiceCollection services)
    {
        var assembly = AppDomain.CurrentDomain.Load("EGestor.Domain");
        services.AddMediatR(assembly);

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IClienteRepository, ClienteRepository>();

        services.AddScoped<IFuncionarioService, FuncionarioService>();
        services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }
}
