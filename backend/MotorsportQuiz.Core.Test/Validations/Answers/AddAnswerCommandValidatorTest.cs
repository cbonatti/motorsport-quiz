using FluentAssertions;
using MotorsportQuiz.Core.Commands.Answer;
using MotorsportQuiz.Core.Validations.Answer;
using MotorsportQuiz.Core.Validations.Answer.Messages;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Test.Answers
{
    [TestFixture]
    public class AddAnswerCommandValidatorTest
    {
        private AddAnswerCommandValidator _validator;
        private const string _existingAnswer = "Alemanha";

        [OneTimeSetUp]
        public void Setup()
        {
            var repo = Substitute.For<IAnswerRepository>();
            repo.VerifyExistence(_existingAnswer, null).Returns(true);
            _validator = new AddAnswerCommandValidator(repo);
        }

        [Test]
        public async Task Should_Not_Validate_Empty_Command()
        {
            var result = await _validator.Validate(new AddAnswerCommand());
            result.Success.Should().BeFalse();
            result.Messages.Contains(AnswerValidationMessages.NAME);
        }

        [Test]
        public async Task Should_Not_Validate_Command_Existing_Name()
        {
            var result = await _validator.Validate(new AddAnswerCommand() { Name = _existingAnswer });
            result.Success.Should().BeFalse();
            result.Messages.Contains(AnswerValidationMessages.NAME_EXISTS);
        }

        [Test]
        public async Task Should_Validate_Command()
        {
            var result = await _validator.Validate(new AddAnswerCommand() { Name = "Inglaterra" });
            result.Success.Should().BeTrue();
            result.Messages.Any().Should().BeFalse();
        }
    }
}
