using MotorsportQuiz.Core.Commands.Question;
using MotorsportQuiz.Infra.Results;

namespace MotorsportQuiz.Core.Validations.Question.Interfaces
{
    public interface IRemoveQuestionCommandValidator
    {
        ValidationResult Validate(RemoveQuestionCommand command);
    }
}
