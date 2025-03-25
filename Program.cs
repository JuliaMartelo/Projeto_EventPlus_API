using Projeto_Event_.Context;
using Projeto_Event_.Interfaces;
using Projeto_Event_.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services // Acessa a cole��o de servi�os da aplica��o (Dependency Injection)
    .AddControllers() // Adiciona suporte a controladores na API (MVC ou Web API)
    .AddJsonOptions(options => // Configura as op��es do serializador JSON padr�o (System.Text.Json)
    {
        // Configura��o para ignorar propriedades nulas ao serializar objetos em JSON
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

        // Configura��o para evitar refer�ncia circular ao serializar objetos que possuem relacionamentos recursivos
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


// Configura??o do banco de dados
builder.Services.AddDbContext<Event_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inje??o de depend?ncia dos reposit?rios
builder.Services.AddScoped<ITiposEventos, TiposEventosRepository>();
builder.Services.AddScoped<ITiposUsuarios, TiposUsuariosRepository>();
builder.Services.AddScoped<IUsuarios, UsuariosRepository>();
builder.Services.AddScoped<IEventos, EventosRepository>();
builder.Services.AddScoped<IComentariosEventos, ComentariosEventosRepository>();
builder.Services.AddScoped<IPresencas, PresencasRepostory>();






//Adiciona o servi?o de Controllers
builder.Services.AddControllers();


var app = builder.Build();

app.MapControllers();

app.Run();