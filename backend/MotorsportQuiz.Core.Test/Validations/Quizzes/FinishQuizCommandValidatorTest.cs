using FluentAssertions;
using MotorsportQuiz.Core.Commands.Quiz;
using MotorsportQuiz.Core.Commands.Quiz.Contracts;
using MotorsportQuiz.Core.Validations.Quiz;
using MotorsportQuiz.Core.Validations.Quiz.Messages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MotorsportQuiz.Core.Test.Validations.Quizzes
{
    [TestFixture]
    public class FinishQuizCommandValidatorTest
    {
        private FinishQuizCommandValidator _validator;

        [OneTimeSetUp]
        public void Setup()
        {
            _validator = new FinishQuizCommandValidator();
        }

        [Test]
        public void Should_Not_Validate_Empty_Command()
        {
            var result = _validator.Validate(new FinishQuizCommand());
            result.Success.Should().BeFalse();
            result.Messages.Should().ContainMatch(QuizValidationMessages.NAME);
            result.Messages.Should().ContainMatch(QuizValidationMessages.NO_ANSWERS);
        }

        [Test]
        public void Should_Not_Validate_Command()
        {
            var result = _validator.Validate(new FinishQuizCommand()
            {
                UserName = "CARLOS",
                Answers = new List<QuizAnswerDto>()
                {
                    new QuizAnswerDto() { QuestionId = Guid.NewGuid() }
                }
            });
            result.Success.Should().BeFalse();
            result.Messages.Should().ContainMatch(QuizValidationMessages.ANSWER);
        }

        [Test]
        public void Should_Validate_Command()
        {
            var result = _validator.Validate(new FinishQuizCommand()
            {
                UserName = "CARLOS",
                Answers = new List<QuizAnswerDto>()
                {
                    new QuizAnswerDto() { AnswerId = Guid.NewGuid(), QuestionId = Guid.NewGuid() }
                }
            });
            result.Success.Should().BeTrue();
            result.Messages.Any().Should().BeFalse();
        }
    }
}
