using ExpenseService.EFConfiguration.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseService.EFConfiguration.Startup
{
    public static class EntityFrameworkStartup
    {
        public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExpenseDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddRepositories();
        }
    }
}
