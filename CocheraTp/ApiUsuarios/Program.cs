using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryUsuario.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryUsuario.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryUsuario.UnitOfWorkUsuario;
using CocheraTp.Servicios.UsuarioServicio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<db_cocherasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUnitOfWorkUsuario, UnitOfWorkUsuario>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
