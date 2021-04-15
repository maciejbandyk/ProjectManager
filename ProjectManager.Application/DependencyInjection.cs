using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
            //TODO: TEST CZY AUTOMAPPER ZADZIALA
            services.AddAutoMapper(/*Assembly.GetExecutingAssembly(),*/ typeof(MappingProfile));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }

    }
}
