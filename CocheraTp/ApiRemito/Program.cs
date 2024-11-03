using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryRemito.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryRemito.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryRemito.UnitOfWorkRemito;
using CocheraTp.Servicios.RemitoServicio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<db_cocherasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepostoryRemito,RepositoryRemito >();
builder.Services.AddScoped<IUnitOfWorkRemito, UnitOfWorkRemito>();
builder.Services.AddScoped<IRemitoServicio, RemitoServicio>();


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
