using MotorsportQuiz.Domain.Base;
using System;

namespace MotorsportQuiz.Domain
{
    public class Answer : EntityBase
    {
        public Answer()
        {
        }

        public Answer(string name)
        {
            SetName(name);
        }

        public Answer(Guid id, string name) : this(name)
        {
            SetId(id);
        }
    }
}
