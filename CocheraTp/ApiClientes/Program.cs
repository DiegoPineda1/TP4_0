using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryCliente.Implemetacion;
using CocheraTp.Repository.CarpetaRepositoryCliente.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryCliente.unitofworkClientes;
using CocheraTp.Repository.unit_of_work;
using CocheraTp.Servicios.ClienteSevicio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<db_cocherasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IUnitOfWorkCliente, UnitOfWorkCliente>();
builder.Services.AddScoped<IClienteServicios, ClienteServicios>();





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
