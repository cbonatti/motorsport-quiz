using MotorsportQuiz.Infra.Responses;
using System.Collections.Generic;

namespace MotorsportQuiz.Core.Responses
{
    public class QuizResponse : ResponseBase
    {
        public IEnumerable<QuestionResponse> Questions { get; set; }
    }
}
