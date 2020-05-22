using MotorsportQuiz.Core.Commands.Answer;
using MotorsportQuiz.Core.Validations.Answer.Interfaces;
using MotorsportQuiz.Core.Validations.Answer.Messages;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using MotorsportQuiz.Infra.Results;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Validations.Answer
{
    public class AddAnswerCommandValidator : IAddAnswerCommandValidator
    {
        private readonly IAnswerRepository _repository;

        public AddAnswerCommandValidator(IAnswerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Validate(AddAnswerCommand command)
        {
            var result = new ValidationResult();
            if (string.IsNullOrEmpty(command.Name))
                result.AddMessage(AnswerValidationMessages.NAME);
            else if (await _repository.VerifyExistence(command.Name, null))
                result.AddMessage(AnswerValidationMessages.NAME_EXISTS);

            return result;
        }
    }
}
