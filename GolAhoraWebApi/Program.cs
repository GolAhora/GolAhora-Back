
using Application.Interfaces.Commands;
using Application.Interfaces.Queries;
using Application.Interfaces.Services;
using Application.UseCases;
using GolAhoraWebApi.Net.Helpers;
using Infraestructure.Persistence;
using Infrastructure.Commands;
using Infrastructure.Persistence;
using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddCors(policy =>
{
    policy.AddDefaultPolicy(options => options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


String? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

connectionString = ConnectionHelper.GetConnectionString(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// ── Cancha ──────────────────────────────────────────────────────────────────
builder.Services.AddScoped<ICanchaService,     CanchaService>();
builder.Services.AddScoped<IQueryCancha,       QueryCancha>();
builder.Services.AddScoped<ICommandCancha,     CommandCancha>();

// ── TipoCancha ───────────────────────────────────────────────────────────────
builder.Services.AddScoped<ITipoCanchaService, TipoCanchaService>();
builder.Services.AddScoped<IQueryTipoCancha,   QueryTipoCancha>();
builder.Services.AddScoped<ICommandTipoCancha, CommandTipoCancha>();

// ── Reserva ───────────────────────────────────────────────────────────────────
builder.Services.AddScoped<IReservaService,   ReservaService>();
builder.Services.AddScoped<IQueryReserva,    QueryReserva>();
builder.Services.AddScoped<ICommandReserva,  CommandReserva>();

// ── Usuario ───────────────────────────────────────────────────────────────────
builder.Services.AddScoped<IUsuarioService,   UsuarioService>();
builder.Services.AddScoped<IQueryUsuario,     QueryUsuario>();
builder.Services.AddScoped<ICommandUsuario,   CommandUsuario>();

// ── Actividad ─────────────────────────────────────────────────────────────────
builder.Services.AddScoped<IActividadService,   ActividadService>();
builder.Services.AddScoped<IQueryActividad,     QueryActividad>();
builder.Services.AddScoped<ICommandActividad,   CommandActividad>();

// ── Cobro ─────────────────────────────────────────────────────────────────────
builder.Services.AddScoped<ICobroService,   CobroService>();
builder.Services.AddScoped<IQueryCobro,     QueryCobro>();
builder.Services.AddScoped<ICommandCobro,   CommandCobro>();

// ── Competencia ───────────────────────────────────────────────────────────────
builder.Services.AddScoped<ICompetenciaService,  CompetenciaService>();
builder.Services.AddScoped<IQueryCompetencia,    QueryCompetencia>();
builder.Services.AddScoped<ICommandCompetencia,  CommandCompetencia>();

// ── Mantenimiento ─────────────────────────────────────────────────────────────
builder.Services.AddScoped<IMantenimientoService,  MantenimientoService>();
builder.Services.AddScoped<IQueryMantenimiento,    QueryMantenimiento>();
builder.Services.AddScoped<ICommandMantenimiento,  CommandMantenimiento>();

// ── Partido ───────────────────────────────────────────────────────────────────
builder.Services.AddScoped<IPartidoService,  PartidoService>();
builder.Services.AddScoped<IQueryPartido,    QueryPartido>();
builder.Services.AddScoped<ICommandPartido,  CommandPartido>();

// ── Recibo ────────────────────────────────────────────────────────────────────
builder.Services.AddScoped<IReciboService,  ReciboService>();
builder.Services.AddScoped<IQueryRecibo,    QueryRecibo>();
builder.Services.AddScoped<ICommandRecibo,  CommandRecibo>();



builder.Services.AddHttpClient();

var app = builder.Build();  

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

await PrepDB.PrepPopulation(app);


app.Run();

