using System;

namespace MotorsportQuiz.Core.Commands.Answer
{
    public class UpdateAnswerCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
