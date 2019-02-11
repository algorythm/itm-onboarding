using Microsoft.Extensions.DependencyInjection;
using todoProject.Services.TodoServices;

namespace todoProject.Services
{
    public static class EfServiceExtensions
    {
        public static void ConfigureEntityExtensions(this IServiceCollection services)
        {
            services.AddScoped<ITodoService, TodoService>();
        }
    }
}