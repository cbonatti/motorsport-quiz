using FluentAssertions;
using MotorsportQuiz.Core.Commands.Question;
using MotorsportQuiz.Core.Commands.Question.Contracts;
using MotorsportQuiz.Core.Validations.Question;
using MotorsportQuiz.Core.Validations.Question.Messages;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Test.Questions
{
    [TestFixture]
    public class UpdateQuestionCommandValidatorTest
    {
        private UpdateQuestionCommandValidator _validator;
        private const string _existingQuestion = "BMW";
        private Guid existingAnswerId = Guid.NewGuid();

        [OneTimeSetUp]
        public void Setup()
        {
            var repo = Substitute.For<IQuestionRepository>();
            repo.VerifyExistence(_existingQuestion, existingAnswerId).Returns(true);
            _validator = new UpdateQuestionCommandValidator(repo);
        }

        [Test]
        public async Task Should_Not_Validate_Empty_Command()
        {
            var result = await _validator.Validate(new UpdateQuestionCommand());
            result.Success.Should().BeFalse();
            result.Messages.Contains(QuestionValidationMessages.NAME);
            result.Messages.Contains(QuestionValidationMessages.NO_ANSWERS);
            result.Messages.Contains(QuestionValidationMessages.NO_CORRECT_ANSWER);
        }

        [Test]
        public async Task Should_Not_Validate_Command_Existing_Name()
        {
            var result = await _validator.Validate(new UpdateQuestionCommand() { Name = _existingQuestion, Id = existingAnswerId });
            result.Success.Should().BeFalse();
            result.Messages.Contains(QuestionValidationMessages.NAME_EXISTS);
        }

        [Test]
        public async Task Should_Not_Validate_Command_No_Answers()
        {
            var result = await _validator.Validate(new UpdateQuestionCommand() { Name = "Mini" });
            result.Success.Should().BeFalse();
            result.Messages.Contains(QuestionValidationMessages.NO_ANSWERS);
        }

        [Test]
        public async Task Should_Not_Validate_Command_No_Correct_Answer()
        {
            var result = await _validator.Validate(new UpdateQuestionCommand()
            {
                Name = "Mini",
                Answers = new List<QuestionAnswerDto>()
            {
                new QuestionAnswerDto() { Id = Guid.NewGuid(), Name = "Alemanha"}
            }
            });
            result.Success.Should().BeFalse();
            result.Messages.Contains(QuestionValidationMessages.NO_CORRECT_ANSWER);
        }

        [Test]
        public async Task Should_Validate_Command()
        {
            var result = await _validator.Validate(new UpdateQuestionCommand()
            {
                Name = "Mini",
                Answers = new List<QuestionAnswerDto>()
            {
                new QuestionAnswerDto() { Id = Guid.NewGuid(), Name = "Alemanha"},
                new QuestionAnswerDto() { Id = Guid.NewGuid(), Name = "Inglaterra", Correct = true }
            }
            });
            result.Success.Should().BeTrue();
            result.Messages.Any().Should().BeFalse();
        }
    }
}
