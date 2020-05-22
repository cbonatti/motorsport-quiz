using MotorsportQuiz.Core.Commands.Question;
using MotorsportQuiz.Core.Validations.Question.Interfaces;
using MotorsportQuiz.Core.Validations.Question.Messages;
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
                result.AddMessage(QuestionValidationMessages.ID);
            return result;
        }

        public bool ValidateId(Guid id) => !id.Equals(Guid.Empty);
    }
}
