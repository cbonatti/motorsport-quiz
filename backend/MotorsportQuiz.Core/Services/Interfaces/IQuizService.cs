using MotorsportQuiz.Core.Commands.Quiz;
using MotorsportQuiz.Core.Responses;
using MotorsportQuiz.Infra.Results;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Services.Interfaces
{
    public interface IQuizService
    {
        Task<Result<QuizResponse>> StartQuiz(StartQuizCommand command);
    }
}
