using MotorsportQuiz.Domain.Base;
using System;
using System.Collections.Generic;

namespace MotorsportQuiz.Domain
{
    public class Question : EntityBase
    {
        public Question()
        {
        }

        public Question(string name, IList<QuestionAnswer> answers)
        {
            SetName(name);
            Answers = answers;
        }

        public Question(Guid id, string name, IList<QuestionAnswer> answers) : this(name, answers)
        {
            SetId(id);
        }

        public virtual IList<QuestionAnswer> Answers { get; private set; }
    }
}
