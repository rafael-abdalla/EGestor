using EGestor.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddJwtConfiguration(configuration);

builder.Services.AddDependencies(configuration);

var app = builder.Build();

app.UseExceptionHandler("/error");

app.UseDependencies();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseJwtConfiguration();

app.MapControllers();

app.Run();
