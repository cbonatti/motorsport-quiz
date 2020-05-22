using FluentAssertions;
using MotorsportQuiz.Core.Commands.Question;
using MotorsportQuiz.Core.Commands.Question.Contracts;
using MotorsportQuiz.Core.Services;
using MotorsportQuiz.Core.Validations.Question;
using MotorsportQuiz.Core.Validations.Question.Interfaces;
using MotorsportQuiz.Core.Validations.Question.Messages;
using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using MotorsportQuiz.Infra.Results;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Test.Services
{
    [TestFixture]
    public class QuestionServiceTest
    {
        private QuestionService _service;
        private Question _question = new Question(Guid.NewGuid(), "TESTE", new List<QuestionAnswer>() { new QuestionAnswer(Guid.NewGuid(), "TESTE", true) });

        [OneTimeSetUp]
        public void Setup()
        {
            var repo = Substitute.For<IQuestionRepository>();
            repo.Get(_question.Id).Returns(_question);
            repo.GetAll().Returns(new List<Question>
            {
                _question,
                new Question(Guid.NewGuid(), "TESTE 2", new List<QuestionAnswer>())
            });
            repo.VerifyExistence(Arg.Any<string>(), null).ReturnsForAnyArgs(false);

            var addValidator = new AddQuestionCommandValidator(repo);
            var updateValidator = new UpdateQuestionCommandValidator(repo);
            var removeValidator = new RemoveQuestionCommandValidator();

            var validationResult = new ValidationResult();
            //addValidator.Validate(Arg.Any<AddQuestionCommand>()).ReturnsForAnyArgs(validationResult);

            _service = new QuestionService(repo, addValidator, updateValidator, removeValidator);
        }

        [Test]
        public async Task Should_Get_Question()
        {
            var result = await _service.Get(_question.Id);
            result.Success.Should().BeTrue();
            result.Value.Name.Should().Be(_question.Name);
        }

        [Test]
        public async Task Should_Not_Get_Question()
        {
            var result = await _service.Get(Guid.NewGuid());
            result.Success.Should().BeTrue();
            result.Value.Should().BeNull();
        }

        [Test]
        public async Task Should_Get_All_Questions()
        {
            var result = await _service.GetAll();
            result.Success.Should().BeTrue();
            result.Value.Count().Should().Be(2);
        }

        [Test]
        public async Task Should_Add_Question()
        {
            var command = new AddQuestionCommand()
            {
                Name = "TESTE",
                Answers = new List<QuestionAnswerDto>()
                {
                    new QuestionAnswerDto() { Id = Guid.NewGuid(), Name = "TESTE", Correct = true }
                }
            };

            var result = await _service.Add(command);
            result.Success.Should().BeTrue();
        }

        [Test]
        public async Task Should_Not_Add_Question()
        {
            var command = new AddQuestionCommand()
            {
                Name = "TESTE",
                Answers = new List<QuestionAnswerDto>()
                {
                    new QuestionAnswerDto() { Id = Guid.NewGuid(), Name = "BMW", Correct = false }
                }
            };

            var result = await _service.Add(command);
            result.Success.Should().BeFalse();
            result.Message.Should().Be(QuestionValidationMessages.NO_CORRECT_ANSWER);
        }

        [Test]
        public async Task Should_Update_Question()
        {
            var command = new UpdateQuestionCommand()
            {
                Id = _question.Id,
                Name = "TESTE",
                Answers = new List<QuestionAnswerDto>()
                {
                    new QuestionAnswerDto() { Id = Guid.NewGuid(), Name = "TESTE", Correct = true }
                }
            };

            var result = await _service.Update(command);
            result.Success.Should().BeTrue();
        }

        [Test]
        public async Task Should_Not_Update_Question()
        {
            var command = new UpdateQuestionCommand()
            {
                Id = _question.Id,
                Name = "TESTE",
                Answers = new List<QuestionAnswerDto>()
                {
                    new QuestionAnswerDto() { Id = Guid.NewGuid(), Name = "BMW", Correct = false }
                }
            };

            var result = await _service.Update(command);
            result.Success.Should().BeFalse();
            result.Message.Should().Be(QuestionValidationMessages.NO_CORRECT_ANSWER);
        }

        [Test]
        public async Task Should_Remove_Question()
        {
            var command = new RemoveQuestionCommand() { Id = _question.Id };

            var result = await _service.Delete(command);
            result.Success.Should().BeTrue();
        }

        [Test]
        public async Task Should_Not_Remove_Question()
        {
            var command = new RemoveQuestionCommand();

            var result = await _service.Delete(command);
            result.Success.Should().BeFalse();
            result.Message.Should().Be(QuestionValidationMessages.ID);
        }
    }
}
