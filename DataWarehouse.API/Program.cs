using Microsoft.OpenApi.Models;
using DataWarehouse.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DataWarehouse API",
        Version = "v1"
    });
});

// Register infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

/* ✅ ENABLE SWAGGER ALWAYS */
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DataWarehouse API v1");
    c.RoutePrefix = string.Empty; // Swagger at root (/)
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

