using MotorsportQuiz.Domain.Base;
using System.Collections.Generic;

namespace MotorsportQuiz.Domain
{
    public class Question : EntityBase
    {
        public virtual IList<QuestionAnswer> Answers { get; private set; }
    }
}
