using MotorsportQuiz.Core.Commands.Question;
using MotorsportQuiz.Core.Responses;
using MotorsportQuiz.Infra.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<Result<QuestionResponse>> Get(Guid id);
        Task<Result<IEnumerable<QuestionResponse>>> GetAll();
        Task<Result<QuestionResponse>> Add(AddQuestionCommand command);
        Task<Result<QuestionResponse>> Update(UpdateQuestionCommand command);
        Task<Result<QuestionResponse>> Delete(RemoveQuestionCommand command);
    }
}
