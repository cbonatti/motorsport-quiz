using System;

namespace MotorsportQuiz.Domain
{
    public class QuestionAnswer
    {
        public QuestionAnswer()
        {
        }

        public QuestionAnswer(Guid id, string name, bool correct)
        {
            Answer = new Answer(id, name);
            Correct = correct;
        }

        public Guid Id { get; private set; }
        public virtual Answer Answer { get; private set; }
        public bool Correct { get; private set; }
    }
}
