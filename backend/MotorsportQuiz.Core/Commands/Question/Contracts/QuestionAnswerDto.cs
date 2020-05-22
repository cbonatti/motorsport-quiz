using System;

namespace MotorsportQuiz.Core.Commands.Question.Contracts
{
    public class QuestionAnswerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Correct { get; set; }
    }
}
