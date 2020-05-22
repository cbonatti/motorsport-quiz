using System;

namespace MotorsportQuiz.Infra.Responses
{
    public abstract class ResponseBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
