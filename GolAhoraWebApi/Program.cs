
using GolAhoraWebApi.Net.Helpers;
using Infrastructure.Persistence;
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

app.Run();

