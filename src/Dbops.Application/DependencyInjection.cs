using MediatR.NotificationPublishers;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Dbops.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services){
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(config => {
            config.RegisterServicesFromAssemblies(assembly);
            config.NotificationPublisher = new ForeachAwaitPublisher();

        });

        //services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
