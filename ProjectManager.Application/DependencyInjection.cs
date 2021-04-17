using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Application.Common.Behaviours;
using ProjectManager.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            return services;
        }

    }
}
