using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MediatR;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CA.Blocks.Application.Mappers;
using CA.Blocks.Application.Common.Behaviours;
using CA.Blocks.Infrastructure.Repositories;
using CA.Blocks.Infrastructure.Data;
using System.Reflection;
using CA.Blocks.Application.Common.Interfaces;
using CA.Blocks.Infrastructure.Contexts;

namespace CA.Blocks.ProjectApi.Configurations;

public static class ProjectServicesDI
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .RegisterRepositories()
            .RegisterDBContext(configuration)
            .RegisterAuthentication()
            .RegisterMediatR()
            .RegisterValidator()
            .RegisterSwagger();

        return services;
    }
    private static IServiceCollection RegisterMediatR(this IServiceCollection services)
    {
        //added
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            //added
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            cfg.RegisterServicesFromAssemblyContaining(typeof(EmployeeMapper));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        return services;
    }

    private static IServiceCollection RegisterValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(EmployeeMapper));

        return services;
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IProjectUnitOfWork), typeof(ProjectUnitOfWork));
        services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
        services.AddScoped(typeof(IJobRepository), typeof(JobRepository));

        return services;
    }

    private static IServiceCollection RegisterDBContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProjectDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
            ServiceLifetime.Scoped);
        services.AddScoped<ApplicationDBContext>(provider => provider.GetService<ProjectDBContext>()!);

        return services;
    }

    private static IServiceCollection RegisterAuthentication(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy("CanDeletePolicy", policy =>
            policy.RequireClaim("Permissions", "CanDelete"));

        return services;
    }

    private static IServiceCollection RegisterSwagger(this IServiceCollection services)
    {
        services.AddSwaggerExamplesFromAssemblyOf(typeof(EmployeeMapper));

        return services;
    }
}
