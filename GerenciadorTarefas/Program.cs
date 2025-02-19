using GerenciadorTarefas.Data;
using GerenciadorTarefas.Repositories;
using GerenciadorTarefas.Services;
using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext com a string de conexão
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra o Repository
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

// Registra o Service
builder.Services.AddScoped<ITarefaService, TarefaService>();

// Registra o RabbitMQPublisher
builder.Services.AddSingleton<IRabbitMQPublisher, RabbitMQPublisher>();

// Configura o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona os controllers
builder.Services.AddControllers();

// Adicionando suporte a CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Constrói o app (somente uma vez)
var app = builder.Build();

// Configura o middleware do Swagger em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplicando o CORS
app.UseCors("PermitirTudo");

// Configura o roteamento para os controllers
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
