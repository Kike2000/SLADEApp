using CongresoSlade.Application.Interfaces;
using CongresoSlade.Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.Extensions
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()
                    .Where(p => !p.IsDynamic));
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IEventoApplication, EventoApplication>();
            services.AddScoped<IParticipanteApplication, ParticipanteApplication>();
            services.AddScoped<IAreaApplication, AreaApplication>();
            return services;
        }
    }
}
