using MotorsportQuiz.Core.Commands.Question.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MotorsportQuiz.Core.Commands.Question
{
    public class UpdateQuestionCommand
    {
        public UpdateQuestionCommand()
        {
            Answers = new List<QuestionAnswerDto>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<QuestionAnswerDto> Answers { get; set; }

        public Domain.Question ToQuestion() => new Domain.Question(Id, Name, Answers.Select(answer => new Domain.QuestionAnswer(answer.Id, answer.Name, answer.Correct)).ToList());
    }
}
