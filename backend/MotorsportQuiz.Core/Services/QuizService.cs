using MotorsportQuiz.Core.Commands.Quiz;
using MotorsportQuiz.Core.Responses;
using MotorsportQuiz.Core.Services.Interfaces;
using MotorsportQuiz.Core.Validations.Quiz.Interfaces;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using MotorsportQuiz.Infra.Results;
using MotorsportQuiz.Infra.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Services
{
    public class QuizService : ValidationServiceBase<QuizResponse>, IQuizService
    {
        private readonly IQuestionRepository _repository;
        private readonly IStartQuizCommandValidator _startQuizCommandValidator;

        public QuizService(IQuestionRepository repository, IStartQuizCommandValidator startQuizCommandValidator)
        {
            _repository = repository;
            _startQuizCommandValidator = startQuizCommandValidator;
        }

        public async Task<Result<QuizResponse>> StartQuiz(StartQuizCommand command)
        {
            var validationResult = Validate(_startQuizCommandValidator.Validate(command));
            if (!validationResult.Success)
                return validationResult;

            var query = await _repository.GetAll();
            var questions = query
                                .Select(QuestionResponse.ToQuizResponse)
                                .OrderBy(question => Guid.NewGuid())
                                .AsEnumerable();
            var response = new QuizResponse() { Questions = questions };
            return new Result<QuizResponse>(response);
        }
    }
}
