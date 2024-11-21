using Microsoft.EntityFrameworkCore;
using SustainableEnergyAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registre o contexto do banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure o pipeline de requisi��o HTTP
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SustainableEnergyAPI v1");
    c.RoutePrefix = string.Empty; // Faz o Swagger aparecer na URL raiz
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
