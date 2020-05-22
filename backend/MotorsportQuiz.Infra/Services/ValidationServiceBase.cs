using MotorsportQuiz.Infra.Data.Interfaces;
using MotorsportQuiz.Infra.Responses;
using MotorsportQuiz.Infra.Results;
using System.Linq;

namespace MotorsportQuiz.Infra.Services
{
    public class ValidationServiceBase<T> : IValidationServiceBase<T> where T : ResponseBase
    {
        public Result<T> Validate(ValidationResult validationResult)
        {
            if (!validationResult.Success)
                return new Result<T>(validationResult.Messages.FirstOrDefault());
            return new Result<T>();
        }
    }
}
