using MotorsportQuiz.Core.Commands.Quiz;
using MotorsportQuiz.Core.Responses;
using MotorsportQuiz.Infra.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Services.Interfaces
{
    public interface IQuizResultService 
    {
        Task<Result<IEnumerable<QuizResultResponse>>> GetAll();
        Task<Result<QuizResultResponse>> FinishQuiz(FinishQuizCommand command);
        Task<double> CalculateResult(FinishQuizCommand command);
    }
}
