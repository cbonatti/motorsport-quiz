using FluentAssertions;
using MotorsportQuiz.Core.Commands.Answer;
using MotorsportQuiz.Core.Validations.Answer;
using MotorsportQuiz.Core.Validations.Answer.Messages;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Test.Answers
{
    [TestFixture]
    public class UpdateAnswerCommandValidatorTest
    {
        private UpdateAnswerCommandValidator _validator;
        private const string _existingAnswerName = "Alemanha";
        private Guid existingAnswerId = Guid.NewGuid();

        [OneTimeSetUp]
        public void Setup()
        {
            var repo = Substitute.For<IAnswerRepository>();
            repo.VerifyExistence(_existingAnswerName, existingAnswerId).Returns(true);
            _validator = new UpdateAnswerCommandValidator(repo);
        }

        [Test]
        public async Task Should_Not_Validate_Empty_Command()
        {
            var result = await _validator.Validate(new UpdateAnswerCommand());
            result.Success.Should().BeFalse();
            result.Messages.Contains(AnswerValidationMessages.NAME);
        }

        [Test]
        public async Task Should_Not_Validate_Command_Existing_Name()
        {
            var result = await _validator.Validate(new UpdateAnswerCommand() { Name = _existingAnswerName, Id = existingAnswerId });
            result.Success.Should().BeFalse();
            result.Messages.Contains(AnswerValidationMessages.NAME_EXISTS);
        }

        [Test]
        public async Task Should_Validate_Command()
        {
            var result = await _validator.Validate(new UpdateAnswerCommand() { Name = "Inglaterra" });
            result.Success.Should().BeTrue();
            result.Messages.Any().Should().BeFalse();
        }
    }
}
