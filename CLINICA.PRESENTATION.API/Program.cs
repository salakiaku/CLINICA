
using Microsoft.OpenApi.Models;
using CLINICA.APPLICATION.USECASES.Extensions;
using CLINICA.INFRASTRUTURE.PERSISTENCES.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CLINICA-API",
        Version = "v1",
        Description = "Primeira versão"
    });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfraPersistence();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API .NET 9 v1");
        c.RoutePrefix = string.Empty; // Swagger abre em "/"
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();




app.MapControllers();

app.Run();
