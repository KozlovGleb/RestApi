using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RestApi.DataAccess.Bootstrap
{
    public static class DbConfigurations
    {
        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(
                options => options.UseNpgsql(
                    configuration.GetConnectionString("ConnStr"),
                    builder => builder.MigrationsAssembly(typeof(DataContext).Assembly.FullName))
            );
        }
    }
}