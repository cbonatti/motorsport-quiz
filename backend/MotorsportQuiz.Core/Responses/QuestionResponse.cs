using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Responses;
using System;
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

        public static QuestionResponse ToQuizResponse(Question question)
        {
            if (question == null)
                return null;
            return new QuestionResponse()
            {
                Id = question.Id,
                Name = question.Name,
                Answers = question.Answers
                                    .Select(answer => AnswerResponse.ToResponse(answer.Answer))
                                    .OrderBy(x => Guid.NewGuid())
                                    .ToList()
            };
        }
    }
}
