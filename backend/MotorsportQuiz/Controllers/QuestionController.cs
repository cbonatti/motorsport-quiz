using Microsoft.AspNetCore.Mvc;
using MotorsportQuiz.Core.Commands.Question;
using MotorsportQuiz.Core.Responses;
using MotorsportQuiz.Core.Services.Interfaces;
using MotorsportQuiz.Infra.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportQuiz.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionController(IQuestionService service)
        {
            _service = service;
        }

        [HttpGet, Route("{id}")]
        public async Task<Result<QuestionResponse>> Get(Guid id) => await _service.Get(id);

        [HttpGet]
        public async Task<Result<IEnumerable<QuestionResponse>>> GetAll() => await _service.GetAll();

        [HttpPost]
        public async Task<Result<QuestionResponse>> Post([FromBody]AddQuestionCommand command) => await _service.Add(command);

        [HttpPut]
        public async Task<Result<QuestionResponse>> Put([FromBody]UpdateQuestionCommand command) => await _service.Update(command);

        [HttpDelete, Route("{id}")]
        public async Task<Result<QuestionResponse>> Delete(Guid id) => await _service.Delete(new RemoveQuestionCommand() { Id = id });
    }
}
