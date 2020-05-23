using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Responses;

namespace MotorsportQuiz.Core.Responses
{
    public class QuizResultResponse : ResponseBase
    {
        public double Result { get; set; }

        public static QuizResultResponse ToResponse(Quiz quiz)
        {
            if (quiz == null)
                return null;
            return new QuizResultResponse()
            {
                Name = quiz.Name,
                Result = quiz.Result
            };
        }
    }
}
