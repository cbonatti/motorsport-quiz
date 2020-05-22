using MotorsportQuiz.Core.Commands.Question;
using MotorsportQuiz.Core.Validations.Question.Interfaces;
using MotorsportQuiz.Core.Validations.Question.Messages;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using MotorsportQuiz.Infra.Results;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Validations.Question
{
    public class UpdateQuestionCommandValidator : IUpdateQuestionCommandValidator
    {
        private readonly IQuestionRepository _repository;

        public UpdateQuestionCommandValidator(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Validate(UpdateQuestionCommand command)
        {
            var result = new ValidationResult();
            if (string.IsNullOrEmpty(command.Name))
                result.AddMessage(QuestionValidationMessages.NAME);
            else if (await _repository.VerifyExistence(command.Name, command.Id))
                result.AddMessage(QuestionValidationMessages.NAME_EXISTS);

            if (!command.Answers.Any())
                result.AddMessage(QuestionValidationMessages.NO_ANSWERS);
            if (!command.Answers.Any(answer => answer.Correct))
                result.AddMessage(QuestionValidationMessages.NO_CORRECT_ANSWER);

            return result;
        }
    }
}
