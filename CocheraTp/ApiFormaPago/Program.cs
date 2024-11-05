using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryFormaPago.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryFormaPago.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryFormaPago.UnitOfWorkFormaPago;
using CocheraTp.Servicios.FormaPagoServicio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<db_cocherasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFormaPagoRepository, FormaPagoRepository>();
builder.Services.AddScoped<IUnitOfWorkFormaPago, UnitOfWorkFormaPago>();
builder.Services.AddScoped<IFormaPagoService, FormaPagoService>();


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
