using MotorsportQuiz.Core.Commands.Answer;
using MotorsportQuiz.Core.Validations.Answer.Interfaces;
using MotorsportQuiz.Core.Validations.Answer.Messages;
using MotorsportQuiz.Infra.Results;
using System;

namespace MotorsportQuiz.Core.Validations.Answer
{
    public class RemoveAnswerCommandValidator : IRemoveAnswerCommandValidator
    {
        public ValidationResult Validate(RemoveAnswerCommand command)
        {
            var result = new ValidationResult();
            if (!ValidateId(command.Id))
                result.AddMessage(AnswerValidationMessages.ID);
            return result;
        }

        public bool ValidateId(Guid id) => !id.Equals(Guid.Empty);
    }
}
