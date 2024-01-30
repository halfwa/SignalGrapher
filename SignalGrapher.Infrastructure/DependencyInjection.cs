using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignalGrapher.Application.Abstractions;
using SignalGrapher.Infrastructure.Persistence;
using SignalGrapher.Infrastructure.Persistence.Repositories;
using SignalGrapher.Infrastructure.Services;

namespace SignalGrapher.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddPersistence(configuration)
            .AddServices();
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork>(sp =>
           sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ISignalRepository, SignalRepository>();

        return services;
    }
    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddScoped<IPlotterService, PlotterService>();
    }
}
