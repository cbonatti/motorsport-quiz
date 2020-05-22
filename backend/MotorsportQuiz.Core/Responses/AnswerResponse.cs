using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Responses;

namespace MotorsportQuiz.Core.Responses
{
    public class AnswerResponse : ResponseBase
    {
        public bool Correct { get; set; }

        public static AnswerResponse ToResponse(Answer answer)
        {
            if (answer == null)
                return null;
            return new AnswerResponse()
            {
                Id = answer.Id,
                Name = answer.Name
            };
        }

        public static AnswerResponse ToResponse(QuestionAnswer questionAnswer)
        {
            if (questionAnswer == null)
                return null;
            return new AnswerResponse()
            {
                Id = questionAnswer.Answer.Id,
                Name = questionAnswer.Answer.Name,
                Correct = questionAnswer.Correct
            };
        }
    }
}
