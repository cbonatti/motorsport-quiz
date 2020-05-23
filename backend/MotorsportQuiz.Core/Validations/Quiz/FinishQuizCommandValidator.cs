using MotorsportQuiz.Core.Commands.Quiz;
using MotorsportQuiz.Core.Validations.Quiz.Interfaces;
using MotorsportQuiz.Core.Validations.Quiz.Messages;
using MotorsportQuiz.Infra.Results;
using System;
using System.Linq;

namespace MotorsportQuiz.Core.Validations.Quiz
{
    public class FinishQuizCommandValidator : IFinishQuizCommandValidator
    {
        public ValidationResult Validate(FinishQuizCommand command)
        {
            var result = new ValidationResult();
            if (string.IsNullOrEmpty(command.UserName))
                result.AddMessage(QuizValidationMessages.NAME);

            if (!command.Answers.Any())
                result.AddMessage(QuizValidationMessages.NO_ANSWERS);
            if (command.Answers.Any(answer => answer.AnswerId == null || answer.AnswerId.Equals(Guid.Empty)))
                result.AddMessage(QuizValidationMessages.ANSWER);

            return result;
        }
    }
}
