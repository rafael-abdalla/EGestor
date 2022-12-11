using EGestor.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddJwtConfiguration(configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddDatabaseConfiguration(configuration);

builder.Services.AddDependencies();

builder.Services.AddCors();

var app = builder.Build();

app.UseExceptionHandler("/error");

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseDatabaseConfiguration();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseJwtConfiguration();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
