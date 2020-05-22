using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MotorsportQuiz.Infra.Data
{
    public static class StartupContext
    {
        public static void AddDbContext(this IServiceCollection services) =>
            services.AddDbContext<MotorsportQuizDbContext>(options =>
                options.UseSqlite(DatabaseConnection.ConnectionConfiguration
                                                    .GetConnectionString("DefaultConnection")));
    }
}
