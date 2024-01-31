using ExpenseService.Domain.Interface.Repositories;
using ExpenseService.EFConfiguration.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseService.EFConfiguration.Startup
{
    public static class RepositoriesStartup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
        }
    }
}
