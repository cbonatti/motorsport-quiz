using Microsoft.AspNetCore.Mvc;
using MotorsportQuiz.Core.Commands.Quiz;
using MotorsportQuiz.Core.Responses;
using MotorsportQuiz.Core.Services.Interfaces;
using MotorsportQuiz.Infra.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportQuiz.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly IQuizResultService _quizResultService;

        public QuizController(IQuizService quizService, IQuizResultService quizResultService)
        {
            _quizService = quizService;
            _quizResultService = quizResultService;
        }

        [HttpPost, Route("start")]
        public async Task<Result<QuizResponse>> Start([FromBody]StartQuizCommand command) => await _quizService.StartQuiz(command);

        [HttpPost, Route("finish")]
        public async Task<Result<QuizResultResponse>> Finish([FromBody]FinishQuizCommand command) => await _quizResultService.FinishQuiz(command);

        [HttpGet, Route("scores")]
        public async Task<Result<IEnumerable<QuizResultResponse>>> GetScores() => await _quizResultService.GetAll();
    }
}
