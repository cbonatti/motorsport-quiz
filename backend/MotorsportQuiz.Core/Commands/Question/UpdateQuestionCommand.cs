using System;

namespace MotorsportQuiz.Core.Commands.Question
{
    public class UpdateQuestionCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
