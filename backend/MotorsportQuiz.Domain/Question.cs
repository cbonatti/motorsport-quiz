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

        public Question(Guid id, string name)
        {
            SetId(id);
            SetName(name);
        }

        public virtual ICollection<QuestionAnswer> Answers { get; private set; }

        public Question AddAnswer(QuestionAnswer answer)
        {
            Answers.Add(answer);
            return this;
        }

        public Question RemoveAnswer(QuestionAnswer answer)
        {
            Answers.Remove(answer);
            return this;
        }
    }
}
