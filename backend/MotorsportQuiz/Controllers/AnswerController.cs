using Microsoft.AspNetCore.Mvc;
using MotorsportQuiz.Core.Commands.Answer;
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
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _service;

        public AnswerController(IAnswerService service)
        {
            _service = service;
        }

        [HttpGet, Route("{id}")]
        public async Task<Result<AnswerResponse>> Get(Guid id) => await _service.Get(id);

        [HttpGet]
        public async Task<Result<IEnumerable<AnswerResponse>>> GetAll() => await _service.GetAll();

        [HttpPost]
        public async Task<Result<AnswerResponse>> Post([FromBody]AddAnswerCommand command) => await _service.Add(command);

        [HttpPut]
        public async Task<Result<AnswerResponse>> Put([FromBody]UpdateAnswerCommand command) => await _service.Update(command);

        [HttpDelete, Route("{id}")]
        public async Task<Result<AnswerResponse>> Delete(Guid id) => await _service.Delete(new RemoveAnswerCommand() { Id = id });
    }
}
