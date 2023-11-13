using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScrumProject.Domain.BackLogs;
using ScrumProject.Domain.Interfaces;
using ScrumProject.Domain.Products;
using ScrumProject.Domain.Releases;
using ScrumProject.Domain.Sprints;
using ScrumProject.Persistence.Repositories;

namespace ScrumProject.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services
        , IConfiguration configuration)
    {
        services.AddDbContext<ScrumDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("ScrumDatabase")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IReleaseRepository, ReleaseRepository>();
        services.AddScoped<ISprintRepository, SprintRepository>();
        services.AddScoped<IBackLogRepository, BackLogRepository>();

        return services;
    }
}
