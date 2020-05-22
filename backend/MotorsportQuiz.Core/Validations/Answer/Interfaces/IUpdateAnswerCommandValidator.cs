using MotorsportQuiz.Core.Commands.Answer;
using MotorsportQuiz.Infra.Results;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Validations.Answer.Interfaces
{
    public interface IUpdateAnswerCommandValidator
    {
        Task<ValidationResult> Validate(UpdateAnswerCommand command);
    }
}
