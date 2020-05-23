using System;

namespace MotorsportQuiz.Core.Commands.Quiz.Contracts
{
    public class QuizAnswerDto
    {
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }
    }
}
