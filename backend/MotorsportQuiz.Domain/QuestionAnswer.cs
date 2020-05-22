using System;

namespace MotorsportQuiz.Domain
{
    public class QuestionAnswer
    {
        public Guid Id { get; private set; }
        public virtual Answer Answer { get; private set; }
        public bool Correct { get; private set; }
    }
}
