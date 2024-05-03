using _1_2_FII.Application.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureRegistrationToDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<_12FIIContext>(options =>
                          options.UseNpgsql(configuration.GetConnectionString("OneTwoFII_EntitiesConnection"),
                          builder => 
                          builder.MigrationsAssembly(typeof(_12FIIContext).Assembly.FullName)));
            services.AddScoped(typeof(IAsyncRepository<>),typeof(BaseRepository<>));
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            return services;
        }
    }
}
