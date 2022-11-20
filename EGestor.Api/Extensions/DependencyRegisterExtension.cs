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
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = AppDomain.CurrentDomain.Load("EGestor.Domain");
        services.AddMediatR(assembly);

        services.AddDbContext<EGestorContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IClienteRepository, ClienteRepository>();

        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }

    public static void UseDependencies(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<EGestorContext>()!;
        context.Database.Migrate();
        context.Database.EnsureCreated();
    }
}
