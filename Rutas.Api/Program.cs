using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlanesVentas.Infraestructura.Adaptadores.Repositorios;
using Rutas.Infraestructura.Adaptadores.Integraciones;
using Rutas.Dominio.Puertos.Integraciones;
using Rutas.Dominio.Puertos.Repositorios;
using Rutas.Dominio.Servicios.Pedidos;
using Rutas.Dominio.Servicios.RutaPedidos;
using Rutas.Dominio.Servicios.Rutas;
using Rutas.Infraestructura.Adaptadores.RepositorioGenerico;
using Rutas.Infraestructura.Adaptadores.Repositorios;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V.1.0.2",
        Title = "Servicio Rutas de entrega",
        Description = "Administración de las rutas de entrega"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
            Array.Empty<string>()
            }
        });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("Rutas.Aplicacion")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Capa Infraestructura
builder.Services.AddDbContext<RutasDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("RutasDbContext")), ServiceLifetime.Transient);
builder.Services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddTransient<IRutasRepositorio, RutasRepositorio>();
builder.Services.AddTransient<IRutaPedidoRepositorio, RutaPedidoRepositorio>();
builder.Services.AddTransient<IParametroRepositorio, ParametroRepositorio>();
builder.Services.AddHttpClient<IServicioPedidosApi, ServicioPedidosApi>(); 
//Capa Dominio - Servicios
builder.Services.AddTransient<CrearRuta>();
builder.Services.AddTransient<ConsultarRuta>();
builder.Services.AddTransient<ObtenerRutas>();
builder.Services.AddTransient<AgregarPedido>();
builder.Services.AddTransient<ConsultarEstadoPedido>();
builder.Services.AddTransient<ConsultarIdPedido>();
builder.Services.AddTransient<ServicioPedido>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
