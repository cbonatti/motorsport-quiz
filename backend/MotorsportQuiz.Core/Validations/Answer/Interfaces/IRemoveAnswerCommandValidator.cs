using MotorsportQuiz.Core.Commands.Answer;
using MotorsportQuiz.Infra.Results;

namespace MotorsportQuiz.Core.Validations.Answer.Interfaces
{
    public interface IRemoveAnswerCommandValidator
    {
        ValidationResult Validate(RemoveAnswerCommand command);
    }
}
