using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TSK.Application.Interfaces;
using TSK.Application.Services;
using TSK.Data;

namespace TSK.IoC
{
    public static class DependencyInjectorExtensions
    {
        public static IServiceCollection AddInfraDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetSection("ConnectionStrings:default").Value));
            services.AddTransients();
            return services;
        }

        private static void AddTransients(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILoginService, LoginService>();
        }
    }
}