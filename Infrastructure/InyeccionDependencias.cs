

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Domain.Repositorios;
using Infrastructure.Repositorio;
using Infrastructure.Base;
using Domain.Abstracto;
using Application.Abstracto;
using Application.Implementacion;

using Infrastructure.Persistencia;


namespace Infrastructure;

public static class InyeccionDeDependencias
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AplicacionDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"),
                b => b.MigrationsAssembly(typeof(AplicacionDbContext).Assembly.FullName)));

        

        //De Infraestructura
        services.AddScoped<IDbContext>(sp => sp.GetRequiredService<AplicacionDbContext>());
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IRepositorioCliente, ClienteRepositorio>();
        services.AddScoped<IRepositorioInfCobro, InformacionCRepositorio>();

        //De Aplicacion
        services.AddScoped<IServicioCobranza, ServicioCobranza>();
        
        return services;
    }
    
    
}