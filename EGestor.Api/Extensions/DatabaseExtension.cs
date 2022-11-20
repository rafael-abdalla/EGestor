using EGestor.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EGestor.Api.Extensions;

public static class DatabaseExtension
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EGestorContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    public static void UseDatabaseConfiguration(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<EGestorContext>()!;
        context.Database.Migrate();
        context.Database.EnsureCreated();
    }
}
