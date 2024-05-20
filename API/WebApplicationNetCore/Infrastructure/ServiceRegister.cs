using AutoMapper;
using MyCollege.Api.Application;
using MyCollege.Api.Data;
using MyCollege.Api.Implementations;
using MyCollege.Api.Services;

namespace MyCollege.Api.Infrastructure
{
    public class ServiceRegister
    {
        public static void Register(IServiceCollection services, MapperConfiguration configuration)
        {
            services.AddScoped<IStudentService, StudentOperations>();
            services.AddScoped<IStudentApplication, StudentApplication>();
            services.AddScoped<ICOMapper, COMapper>(c => new COMapper(configuration));
            services.AddScoped<IStudentInfoManger, StudentInfoManager>();
        }
    }
}
