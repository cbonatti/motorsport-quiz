using MotorsportQuiz.Core.Commands.Quiz;
using MotorsportQuiz.Core.Responses;
using MotorsportQuiz.Core.Services.Interfaces;
using MotorsportQuiz.Core.Validations.Quiz.Interfaces;
using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using MotorsportQuiz.Infra.Results;
using MotorsportQuiz.Infra.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Services
{
    public class QuizResultService : ValidationServiceBase<QuizResultResponse>, IQuizResultService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IFinishQuizCommandValidator _finishQuizCommandValidator;

        public QuizResultService(IQuizRepository quizRepository, IQuestionRepository questionRepository, IFinishQuizCommandValidator finishQuizCommandValidator)
        {
            _quizRepository = quizRepository;
            _questionRepository = questionRepository;
            _finishQuizCommandValidator = finishQuizCommandValidator;
        }

        public async Task<Result<IEnumerable<QuizResultResponse>>> GetAll()
        {
            var query = await _quizRepository.GetAll();
            var quizzes = query
                            .OrderByDescending(quiz => quiz.Result)
                            .ThenBy(quiz => quiz.Name)
                            .Select(QuizResultResponse.ToResponse)
                            .AsEnumerable();

            return new Result<IEnumerable<QuizResultResponse>>(quizzes);
        }

        public async Task<Result<QuizResultResponse>> FinishQuiz(FinishQuizCommand command)
        {
            var validationResult = Validate(_finishQuizCommandValidator.Validate(command));
            if (!validationResult.Success)
                return validationResult;

            var quizResult = await CalculateResult(command);
            var quiz = new Quiz(command.UserName, quizResult);
            await _quizRepository.Add(quiz);

            return new Result<QuizResultResponse>(QuizResultResponse.ToResponse(quiz));
        }

        public async Task<double> CalculateResult(FinishQuizCommand command)
        {
            var questionIds = command.Answers.Select(question => question.QuestionId).ToList();
            var questionsQuery = await _questionRepository.GetAll(questionIds);
            var questions = questionsQuery.Select(question => new 
            { 
                QuestionId = question.Id,
                AnswerId = question.Answers.FirstOrDefault(answer => answer.Correct).Answer.Id 
            });

            var rightAnswers = questions.Count(question => command.Answers.Any(answer => answer.QuestionId == question.QuestionId && answer.AnswerId == question.AnswerId));
            return ((double)rightAnswers / questionIds.Count) * 100;
        }
    }
}
