using MotorsportQuiz.Core.Commands.Question.Contracts;
using System.Collections.Generic;
using System.Linq;

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

        public Domain.Question ToQuestion() => new Domain.Question(Name, Answers.Select(answer => new Domain.QuestionAnswer(answer.Id, answer.Correct)).ToList());
    }
}
