using FluentAssertions;
using MotorsportQuiz.Core.Commands.Quiz;
using MotorsportQuiz.Core.Validations.Quiz;
using MotorsportQuiz.Core.Validations.Quiz.Messages;
using NUnit.Framework;
using System.Linq;

namespace MotorsportQuiz.Core.Test.Validations.Quizzes
{
    [TestFixture]
    public class StartQuizCommandValidatorTest
    {
        private StartQuizCommandValidator _validator;

        [OneTimeSetUp]
        public void Setup()
        {
            _validator = new StartQuizCommandValidator();
        }

        [Test]
        public void Should_Not_Validate_Empty_Command()
        {
            var result = _validator.Validate(new StartQuizCommand());
            result.Success.Should().BeFalse();
            result.Messages.Should().ContainMatch(QuizValidationMessages.NAME);
        }

        [Test]
        public void Should_Validate_Command()
        {
            var result = _validator.Validate(new StartQuizCommand() { UserName = "CARLOS" });
            result.Success.Should().BeTrue();
            result.Messages.Any().Should().BeFalse();
        }
    }
}
