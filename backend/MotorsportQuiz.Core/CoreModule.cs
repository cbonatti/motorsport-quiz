using Microsoft.Extensions.DependencyInjection;
using MotorsportQuiz.Core.Validations.Answer;
using MotorsportQuiz.Core.Validations.Answer.Interfaces;

namespace MotorsportQuiz.Core
{
    public static class CoreModule
    {
        public static void RegisterCore(this IServiceCollection services)
        {
            RegisterServices(services);
            RegisterValidators(services);
        }

        private static void RegisterServices(this IServiceCollection services)
        {
        }

        private static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IAddAnswerCommandValidator, AddAnswerCommandValidator>();
            services.AddScoped<IUpdateAnswerCommandValidator, UpdateAnswerCommandValidator>();
            services.AddScoped<IRemoveAnswerCommandValidator, RemoveAnswerCommandValidator>();
        }
    }
}
