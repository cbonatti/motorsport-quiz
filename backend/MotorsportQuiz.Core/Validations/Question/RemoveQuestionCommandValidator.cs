using MotorsportQuiz.Core.Commands.Question;
using MotorsportQuiz.Core.Validations.Answer.Messages;
using MotorsportQuiz.Core.Validations.Question.Interfaces;
using MotorsportQuiz.Infra.Results;
using System;

namespace MotorsportQuiz.Core.Validations.Question
{
    public class RemoveQuestionCommandValidator : IRemoveQuestionCommandValidator
    {
        public ValidationResult Validate(RemoveQuestionCommand command)
        {
            var result = new ValidationResult();
            if (!ValidateId(command.Id))
                result.AddMessage(AnswerValidationMessages.ID);
            return result;
        }

        public bool ValidateId(Guid id) => !id.Equals(Guid.Empty);
    }
}
