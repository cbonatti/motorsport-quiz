using MotorsportQuiz.Infra.Results;

namespace MotorsportQuiz.Infra.Data.Interfaces
{
    public interface IValidationServiceBase<T> where T : class
    {
        Result<T> Validate(ValidationResult validationResult);
    }
}
