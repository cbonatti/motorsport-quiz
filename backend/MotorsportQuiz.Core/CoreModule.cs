using Microsoft.Extensions.DependencyInjection;
using MotorsportQuiz.Core.Services;
using MotorsportQuiz.Core.Services.Interfaces;
using MotorsportQuiz.Core.Validations.Answer;
using MotorsportQuiz.Core.Validations.Answer.Interfaces;
using MotorsportQuiz.Core.Validations.Question;
using MotorsportQuiz.Core.Validations.Question.Interfaces;
using MotorsportQuiz.Core.Validations.Quiz;
using MotorsportQuiz.Core.Validations.Quiz.Interfaces;

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
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuizResultService, QuizResultService>();
            services.AddScoped<IAnswerService, AnswerService>();
        }

        private static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IAddAnswerCommandValidator, AddAnswerCommandValidator>();
            services.AddScoped<IUpdateAnswerCommandValidator, UpdateAnswerCommandValidator>();
            services.AddScoped<IRemoveAnswerCommandValidator, RemoveAnswerCommandValidator>();

            services.AddScoped<IAddQuestionCommandValidator, AddQuestionCommandValidator>();
            services.AddScoped<IUpdateQuestionCommandValidator, UpdateQuestionCommandValidator>();
            services.AddScoped<IRemoveQuestionCommandValidator, RemoveQuestionCommandValidator>();

            services.AddScoped<IFinishQuizCommandValidator, FinishQuizCommandValidator>();
        }
    }
}
