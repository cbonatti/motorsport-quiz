using MotorsportQuiz.Domain.Base;
using System;

namespace MotorsportQuiz.Domain
{
    public class Quiz : EntityBase
    {
        public Quiz()
        {
        }

        public Quiz(string name, double result)
        {
            SetName(name);
            Result = result;
            CreatedDate = DateTime.Now;
        }

        public double Result { get; private set; }
        public DateTime CreatedDate { get; private set; }
    }
}
