using Challenge.Application.Dtos.Permission;
using Challenge.Application.Services;
using Challenge.Application.Services.Contracs;
using Challenge.Application.Services.MessageResultServices;
using Challenge.Common.Exceptions.Helpers;
using Challenge.Common.Utils.Contracts;
using Challenge.Common.Utils.FluentValidatior;
using Challenge.Common.Utils.Services;
using Challenge.Domain.core.Aggregates.PermissionAggregate;
using Challenge.Domain.core.SeedWork;
using Challenge.Infrastructure.Persistence.Context;
using Challenge.Infrastructure.Persistence.Repositories;
using Challenge.Infrastructure.Persistence.UoW;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Challenge.Common.IoC.Config
{
    public static class ContainerIoC
    {

        public static void InjectionDependecy_Repository(this IServiceCollection services)
        {
            //services.AddScoped<DbContext, CommissionContext>();
            services.AddScoped<DbContext>(sp => sp.GetService<ChallengeContext>());
            // Unit of Work
            services.AddScoped<IUnitofWorkChallenge, UnitofWorkChallenge>();
            // Repository
            services.AddScoped<IPermissionRepository, PermissionRepository>();
        }

        public static void InjectionDependecy_Services(this IServiceCollection services)
        {
            //Services Application
            services.AddScoped<IPermissionApplicationService, PermissionApplicationService>();


            // Services Common
            services.AddSingleton<ISerializeJson, SerializeJson>();
        }

        public static void InjectionDependecy_ExceptionHandler(this IServiceCollection services)
        {
            services.AddSingleton<ILog, LogNLog>();
        }

        public static void InjectionDependecy_Validation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<Permissiondto>, PermissionValidator>();
        }



        public static void InjectionDependecy_ResultMessage(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddSingleton<IResultMessage>((serviceProvider) =>
            {
                return new ResultMessage()
                {
                    Message = Configuration.
                            GetSection("Message").
                            GetChildren().
                            ToDictionary(x => x.Key,
                            x => Configuration.GetSection($"Message:{x.Key}").
                            GetChildren().
                            ToDictionary(y => y.Key, y => y.Value))
                };
            });
        }

    }
}
