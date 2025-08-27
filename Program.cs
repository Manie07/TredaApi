using Microsoft.EntityFrameworkCore;
using TredaApi.Data;
using TredaApi.Interfaces;
using TredaApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias para EF y repositorios
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
    c.RoutePrefix = string.Empty; // Abre Swagger en https://localhost:7145 directamente
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();