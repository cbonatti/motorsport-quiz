using MotorsportQuiz.Core.Commands.Question;
using MotorsportQuiz.Infra.Results;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Validations.Question.Interfaces
{
    public interface IUpdateQuestionCommandValidator
    {
        Task<ValidationResult> Validate(UpdateQuestionCommand command);
    }
}
