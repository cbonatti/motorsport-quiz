using MotorsportQuiz.Core.Commands.Answer;
using MotorsportQuiz.Core.Responses;
using MotorsportQuiz.Infra.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Services.Interfaces
{
    public interface IAnswerService
    {
        Task<Result<AnswerResponse>> Get(Guid id);
        Task<Result<IEnumerable<AnswerResponse>>> GetAll();
        Task<Result<AnswerResponse>> Add(AddAnswerCommand command);
        Task<Result<AnswerResponse>> Update(UpdateAnswerCommand command);
        Task<Result<AnswerResponse>> Delete(RemoveAnswerCommand command);
    }
}
