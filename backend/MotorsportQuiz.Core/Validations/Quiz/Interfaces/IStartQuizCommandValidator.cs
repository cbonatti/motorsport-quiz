using MotorsportQuiz.Core.Commands.Quiz;
using MotorsportQuiz.Infra.Results;

namespace MotorsportQuiz.Core.Validations.Quiz.Interfaces
{
    public interface IStartQuizCommandValidator
    {
        ValidationResult Validate(StartQuizCommand command);
    }
}
