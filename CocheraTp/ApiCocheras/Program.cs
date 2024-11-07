using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryAbono.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryAbono.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryAbono.UnitOfWorkAbono;
using CocheraTp.Repository.CarpetaRepositoryCliente.Implemetacion;
using CocheraTp.Repository.CarpetaRepositoryCliente.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryCliente.unitofworkClientes;
using CocheraTp.Repository.CarpetaRepositoryCondicionIVA.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryCondicionIVA.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryDetalleFactura.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryDetalleFactura.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryDetalleFactura.UnitOfWorkDetalleFactura;
using CocheraTp.Repository.CarpetaRepositoryFactura.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryFactura.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryFactura.UnitOfWorkFactura;
using CocheraTp.Repository.CarpetaRepositoryFormaPago.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryFormaPago.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryFormaPago.UnitOfWorkFormaPago;
using CocheraTp.Repository.CarpetaRepositoryLugar.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryLugar.UnitofWorkLugar;
using CocheraTp.Repository.CarpetaRepositoryMarca.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryMarca.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryMarca.UnitOfWorkMarca;
using CocheraTp.Repository.CarpetaRepositoryModelo.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryModelo.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryModelo.UnitOfWorkModelo;
using CocheraTp.Repository.CarpetaRepositoryRemito.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryRemito.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryRemito.UnitOfWorkRemito;
using CocheraTp.Repository.CarpetaRepositoryTipoDocumento.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryTipoDocumento.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryTipoDocumento.UnitOfWorkTipoDoc;
using CocheraTp.Repository.CarpetaRepositoryTipoFactura.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryTipoFactura.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryTipoFactura.UnitOfWorkTipoFac;
using CocheraTp.Repository.CarpetaRepositoryTipoVehiculo.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryTipoVehiculo.Interface;
using CocheraTp.Repository.CarpetaRepositoryUsuario.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryUsuario.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryUsuario.UnitOfWorkUsuario;
using CocheraTp.Repository.CarpetaRepositoryVehiculo.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryVehiculo.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryVehiculo.UnitofWorkVehiculo;
using CocheraTp.Repository.unit_of_work;
using CocheraTp.Servicios.AbonoServicio;
using CocheraTp.Servicios.ClienteSevicio;
using CocheraTp.Servicios.CondicionesIVAServicio;
using CocheraTp.Servicios.DetalleFacturaServicio;
using CocheraTp.Servicios.FacturaServicio;
using CocheraTp.Servicios.FormaPagoServicio;
using CocheraTp.Servicios.LugarServicio;
using CocheraTp.Servicios.MarcaServicio;
using CocheraTp.Servicios.ModeloServicio;
using CocheraTp.Servicios.RemitoServicio;
using CocheraTp.Servicios.TipoFacServicio;
using CocheraTp.Servicios.TiposDocServicio;
using CocheraTp.Servicios.TipoVehiculoService;
using CocheraTp.Servicios.UsuarioServicio;
using CocheraTp.Servicios.VehiculoServicio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<db_cocherasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// SCOPED Vehiculos
builder.Services.AddScoped<IVehiculoServicio, VehiculoServicio>();
builder.Services.AddScoped<IUnitOfWorkVehiculo, UnitOfWorkVehiculo>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
// SCOPED Tipo Documento
builder.Services.AddScoped<ITipoDocRepository, TipoDocRepository>();
builder.Services.AddScoped<IUnitOfWorkTipoDoc, UnitOfWorkTipoDoc>();
builder.Services.AddScoped<ITipoDocService, TipoDocService>();
// SCOPED Remito
builder.Services.AddScoped<IRepostoryRemito, RepositoryRemito>();
builder.Services.AddScoped<IUnitOfWorkRemito, UnitOfWorkRemito>();
builder.Services.AddScoped<IRemitoServicio, RemitoServicio>();
// SCOPED Modelos
builder.Services.AddScoped<IModeloRepository, ModeloRepository>();
builder.Services.AddScoped<IUnitOfWorkModelo, UnitOfWorkModelo>();
builder.Services.AddScoped<IModeloService, ModeloService>();
// SCOPED Marcas
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<IUnitOfWorkMarca, UnitOfWorkMarca>();
builder.Services.AddScoped<IMarcaService, MarcaService>();
// SCOPED Lugares
builder.Services.AddScoped<ILugarRepository, LugarRepository>();
builder.Services.AddScoped<IUnitOfWorkLugar, UnitOfWorkLugar>();
builder.Services.AddScoped<ILugarService, LugarService>();
// SCOPED Facturas / Detalle Facturas
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IUnitOfWorkFactura, UnitOfWorkFactura>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IDetalleFacturaRepository, DetalleFacturaRepository>();
builder.Services.AddScoped<IUnitOfWorkDetalleFactura, UnitOfWorkDetalleFactura>();
builder.Services.AddScoped<IDetalleFacturaServicio, DetalleFacturaServicio>();
// SCOPED Condiciones IVA
builder.Services.AddScoped<ICondicionesIVARepository, CondicionesIVARepository>();
builder.Services.AddScoped<ICondicionesIVAService, CondicionesIVAService>();
// SCOPED Clientes
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IUnitOfWorkCliente, UnitOfWorkCliente>();
builder.Services.AddScoped<IClienteServicios, ClienteServicios>();
// SCOPED Abonos
builder.Services.AddScoped<IAbonoRepository, AbonoRepository>();
builder.Services.AddScoped<IUnitOfWorkAbono, UnitOfWorkAbono>();
builder.Services.AddScoped<IAbonoServicios, AbonoServicios>();
// SCOPED Usuarios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUnitOfWorkUsuario, UnitOfWorkUsuario>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
// SCOPED Tipo Vehiculos
builder.Services.AddScoped<ITipoVehiculoRepository, TipoVehiculoRepository>();
builder.Services.AddScoped<ITipoVehiculoService, TipoVehiculoService>();
// SCOPED Forma pago
builder.Services.AddScoped<IFormaPagoRepository, FormaPagoRepository>();
builder.Services.AddScoped<IUnitOfWorkFormaPago, UnitOfWorkFormaPago>();
builder.Services.AddScoped<IFormaPagoService, FormaPagoService>();
// SCOPED Tipo Facturas
builder.Services.AddScoped<ITipoFacRepository, TipoFacRepository>();
builder.Services.AddScoped<IUnitOfWorkTipoFac, UnitOfWorkTipoFac>();
builder.Services.AddScoped<ITipoFacService, TipoFacService>();

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
