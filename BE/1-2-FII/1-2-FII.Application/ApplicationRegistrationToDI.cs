using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace _1_2_FII.Application
{
    public static class ApplicationRegistrationToDI
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR
                (
                    cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                );
        }
    }
}
