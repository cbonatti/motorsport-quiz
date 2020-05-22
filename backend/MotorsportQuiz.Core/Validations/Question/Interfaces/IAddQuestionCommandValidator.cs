using MotorsportQuiz.Core.Commands.Question;
using MotorsportQuiz.Infra.Results;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Validations.Question.Interfaces
{
    public interface IAddQuestionCommandValidator
    {
        Task<ValidationResult> Validate(AddQuestionCommand command);
    }
}
