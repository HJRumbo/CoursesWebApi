using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();

            return services;
        }
    }
}
