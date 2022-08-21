using ADPortsTask.Repositories;
using ADPortsTask.Repositories.Interfaces;
using ADPortsTask.Services;
using ADPortsTask.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ADPortsTask.Helpers
{
    public static class InitializeServicesExtension
    {
        public static void InitializeServices(this IServiceCollection services)
        {
            
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();           
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMapperService, MapperService>();
        }
    }
}
