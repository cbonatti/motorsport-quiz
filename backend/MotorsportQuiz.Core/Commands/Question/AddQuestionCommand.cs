using MotorsportQuiz.Core.Commands.Question.Contracts;
using System.Collections.Generic;

namespace MotorsportQuiz.Core.Commands.Question
{
    public class AddQuestionCommand
    {
        public AddQuestionCommand()
        {
            Answers = new List<QuestionAnswerDto>();
        }

        public string Name { get; set; }
        public IList<QuestionAnswerDto> Answers { get; set; }
    }
}
