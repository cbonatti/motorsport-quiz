using MotorsportQuiz.Core.Commands.Quiz;
using MotorsportQuiz.Core.Validations.Quiz.Interfaces;
using MotorsportQuiz.Core.Validations.Quiz.Messages;
using MotorsportQuiz.Infra.Results;

namespace MotorsportQuiz.Core.Validations.Quiz
{
    public class StartQuizCommandValidator : IStartQuizCommandValidator
    {
        public ValidationResult Validate(StartQuizCommand command)
        {
            var result = new ValidationResult();
            if (string.IsNullOrEmpty(command.UserName))
                result.AddMessage(QuizValidationMessages.NAME);

            return result;
        }
    }
}
