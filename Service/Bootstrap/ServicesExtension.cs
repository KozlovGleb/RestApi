using Microsoft.Extensions.DependencyInjection;
using RestApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Service.Bootstrap
{
    public static class ServicesExtension
    {
        public static void ServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
        }
    }
}
