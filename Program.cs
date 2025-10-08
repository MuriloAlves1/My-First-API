using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona controllers
builder.Services.AddControllers();

// Adiciona Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My First API",
        Version = "v1",
        Description = "API for testing and learning"
    });
});

var app = builder.Build();

// Habilita Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My First API V1");
    c.RoutePrefix = "swagger"; // acesso via /swagger
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
