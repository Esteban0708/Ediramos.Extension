using System.Reflection;
using Ediramos.Extension.Aplicacion.Commands.Objetivo;
using Ediramos.Extension.Aplicacion.Commands.Usuario;
using Ediramos.Extension.Aplicacion.Servicios;
using Ediramos.Extension.Aplicacion.Validaciones.Convocatoria;
using Ediramos.Extension.Aplicacion.Validaciones.Objetivo;
using Ediramos.Extension.Aplicacion.Validaciones.RolPermiso;
using Ediramos.Extension.Aplicacion.Validaciones.Usuario;
using Ediramos.Extension.Dominio.Repositorios;
using Ediramos.Extension.Infraestructura.Config;
using Ediramos.Extension.Infraestructura.Persistencia;
using Ediramos.Extension.Infraestructura.Repositorios;
using FluentValidation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConnectionSettings>(
    builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddScoped<DbConnectionFactory>();
builder.Services.AddScoped<IObjetivoRepository, ObjetivoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPrefijoUserRepository, PrefijoRepository>();
builder.Services.AddScoped<ISesionRepository, SesionRepository>();
builder.Services.AddScoped<IDivisionRepository, DivisionRepository>();
builder.Services.AddScoped<IConvocatoriaRepository, ConvocatoriaRepository>();
builder.Services.AddScoped<ILineaRepository, LineaRepository>();
builder.Services.AddScoped<IItemsRepository, ItemRepository>();
builder.Services.AddScoped<IPermisosRepository, PermisosRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IGrupoRepository, GrupoRepository>();
builder.Services.AddScoped<IModalidadRepository, ModalidadRepository>();
builder.Services.AddScoped<IAreaTrabajoRepository, AreaTrabajoRepository>();
builder.Services.AddScoped<ICicloVidaRepository, CicloVidaRepository>();
builder.Services.AddScoped<IPoblacionRepository, PoblacionCondicionRepository>();
builder.Services.AddScoped<IUsuarioExternoRepository, UsuarioExternoRepository>();
builder.Services.AddScoped<IInscripcionGrupoRepository, InscripcionGrupoRepository>();
builder.Services.AddScoped<IInforCoordinadorRepository, InfoCoordinadorRepository>();
builder.Services.AddScoped<IPoblacionGrupoRepository, PoblacionGrupoRepository>();
builder.Services.AddScoped<IClaseRepository, ClaseRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();

builder.Services.AddValidatorsFromAssemblyContaining<CrearObjetivoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BuscadorValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CrearConvocatoriaValidator> ();
builder.Services.AddValidatorsFromAssemblyContaining<CrearRolValidator>();


builder.Services.AddTransient<CorreoService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
