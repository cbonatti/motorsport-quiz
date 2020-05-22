using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MotorsportQuiz.Infra.Data.Interfaces;
using MotorsportQuiz.Infra.Data;
using MotorsportQuiz.Infra.Services;
using MotorsportQuiz.Infra.Data.Repositories;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;

namespace MotorsportQuiz.Infra
{
    public static class InfraModule
    {
        public static void RegisterInfra(this IServiceCollection services)
        {
            // Base
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddScoped(typeof(IValidationServiceBase<>), typeof(ValidationServiceBase<>));

            // Repositories
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
        }

        public static void ConfigureContext(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MotorsportQuizDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
