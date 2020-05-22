using System.Collections.Generic;
using System.Linq;

namespace MotorsportQuiz.Infra.Results
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            Messages = new List<string>();
        }

        public IList<string> Messages { get; private set; }
        public bool Success => !Messages.Any();

        public ValidationResult AddMessage(string message)
        {
            Messages.Add(message);
            return this;
        }
    }
}
