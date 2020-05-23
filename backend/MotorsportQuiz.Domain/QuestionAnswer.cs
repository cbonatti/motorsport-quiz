using System;

namespace MotorsportQuiz.Domain
{
    public class QuestionAnswer
    {
        public QuestionAnswer()
        {
            Id = Guid.NewGuid();
        }

        public QuestionAnswer(Guid id, string name, bool correct) : this()
        {
            Answer = new Answer(id, name);
            Correct = correct;
        }

        public QuestionAnswer(Guid questionId, Guid answerID, bool correct) : this()
        {
            QuestionId = questionId;
            AnswerId = answerID;
            Correct = correct;
        }

        public Guid Id { get; private set; }
        public Guid AnswerId { get; private set; }
        public virtual Answer Answer { get; private set; }
        public Guid QuestionId { get; private set; }
        public virtual Question Question { get; private set; }
        public bool Correct { get; private set; }
    }
}
