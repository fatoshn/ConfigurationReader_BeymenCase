using Configuration.Business.CommandHandler;
using Configuration.Business.QueryHandler;
using Configuration.Data.Repositories;
using Configuration.Data.Repositories.Implementation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Configuration.Business.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependenciyInjection(this IServiceCollection services)
        {
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();

            services.AddMediatR(typeof(AddConfigurationCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteConfigurationCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateConfigurationCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetConfigurationByIdQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetConfigurationListQueryHandler).GetTypeInfo().Assembly);
            return services;
        }
    }
}
