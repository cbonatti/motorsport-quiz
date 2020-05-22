using MotorsportQuiz.Core.Commands.Question.Contracts;
using System;
using System.Collections.Generic;

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
    }
}
