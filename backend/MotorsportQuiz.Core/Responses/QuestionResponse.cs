using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Responses;
using System.Collections.Generic;
using System.Linq;

namespace MotorsportQuiz.Core.Responses
{
    public class QuestionResponse : ResponseBase
    {
        public IList<AnswerResponse> Answers { get; set; }
        public static QuestionResponse ToResponse(Question question)
        {
            if (question == null)
                return null;
            return new QuestionResponse()
            {
                Id = question.Id,
                Name = question.Name,
                Answers = question.Answers.Select(AnswerResponse.ToResponse).ToList()
            };
        }
    }
}
