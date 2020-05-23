using MotorsportQuiz.Core.Commands.Quiz.Contracts;
using System.Collections.Generic;

namespace MotorsportQuiz.Core.Commands.Quiz
{
    public class FinishQuizCommand
    {
        public string UserName { get; set; }
        public List<QuizAnswerDto> Answers { get; set; }
    }
}
