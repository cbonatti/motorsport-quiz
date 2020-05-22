using FluentAssertions;
using Microsoft.EntityFrameworkCore.Internal;
using MotorsportQuiz.Core.Commands.Answer;
using MotorsportQuiz.Core.Validations.Answer;
using MotorsportQuiz.Core.Validations.Answer.Messages;
using NUnit.Framework;
using System;
namespace MotorsportQuiz.Core.Test.Answer
{
    [TestFixture]
    public class RemoveAnswerCommandValidatorTest
    {
        private RemoveAnswerCommandValidator _validator;

        [OneTimeSetUp]
        public void Setup()
        {
            _validator = new RemoveAnswerCommandValidator();
        }

        [Test]
        public void Should_Not_Validate_Empty_Command()
        {
            var result = _validator.Validate(new RemoveAnswerCommand());
            result.Success.Should().BeFalse();
            result.Messages.Contains(AnswerValidationMessages.ID);
        }

        [Test]
        public void Should_Validate_Command()
        {
            var result = _validator.Validate(new RemoveAnswerCommand() { Id = Guid.NewGuid() });
            result.Success.Should().BeTrue();
            result.Messages.Any().Should().BeFalse();
        }
    }
}
