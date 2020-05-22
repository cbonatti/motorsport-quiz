using FluentAssertions;
using Microsoft.EntityFrameworkCore.Internal;
using MotorsportQuiz.Core.Commands.Question;
using MotorsportQuiz.Core.Validations.Question;
using MotorsportQuiz.Core.Validations.Question.Messages;
using NUnit.Framework;
using System;

namespace MotorsportQuiz.Core.Test.Question
{
    [TestFixture]
    public class RemoveQuestionCommandValidatorTest
    {
        private RemoveQuestionCommandValidator _validator;

        [OneTimeSetUp]
        public void Setup()
        {
            _validator = new RemoveQuestionCommandValidator();
        }

        [Test]
        public void Should_Not_Validate_Empty_Command()
        {
            var result = _validator.Validate(new RemoveQuestionCommand());
            result.Success.Should().BeFalse();
            result.Messages.Contains(QuestionValidationMessages.ID);
        }

        [Test]
        public void Should_Validate_Command()
        {
            var result = _validator.Validate(new RemoveQuestionCommand() { Id = Guid.NewGuid() });
            result.Success.Should().BeTrue();
            result.Messages.Any().Should().BeFalse();
        }
    }
}
