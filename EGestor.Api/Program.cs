using EGestor.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddJwtConfiguration(configuration);

builder.Services.AddDatabaseConfiguration(configuration);

builder.Services.AddDependencies();

var app = builder.Build();

app.UseExceptionHandler("/error");

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseDatabaseConfiguration();

app.UseJwtConfiguration();

app.MapControllers();

app.Run();
