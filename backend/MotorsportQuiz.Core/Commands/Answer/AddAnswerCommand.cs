namespace MotorsportQuiz.Core.Commands.Answer
{
    public class AddAnswerCommand
    {
        public string Name { get; set; }

        public Domain.Answer ToAnswer() => new Domain.Answer(Name);
    }
}
