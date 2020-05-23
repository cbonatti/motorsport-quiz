using FluentAssertions;
using MotorsportQuiz.Core.Commands.Answer;
using MotorsportQuiz.Core.Services;
using MotorsportQuiz.Core.Validations.Answer;
using MotorsportQuiz.Core.Validations.Answer.Messages;
using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Test.Services
{
    [TestFixture]
    public class AnswerServiceTest
    {
        private AnswerService _service;
        private Answer _Answer = new Answer(Guid.NewGuid(), "TESTE");

        [OneTimeSetUp]
        public void Setup()
        {
            var repo = Substitute.For<IAnswerRepository>();
            repo.Get(_Answer.Id).Returns(_Answer);
            repo.GetAll().Returns(new List<Answer>
            {
                _Answer,
                new Answer(Guid.NewGuid(), "TESTE 2")
            });
            repo.VerifyExistence(Arg.Any<string>(), null).ReturnsForAnyArgs(false);

            var addValidator = new AddAnswerCommandValidator(repo);
            var updateValidator = new UpdateAnswerCommandValidator(repo);
            var removeValidator = new RemoveAnswerCommandValidator();

            _service = new AnswerService(repo, addValidator, updateValidator, removeValidator);
        }

        [Test]
        public async Task Should_Get_Answer()
        {
            var result = await _service.Get(_Answer.Id);
            result.Success.Should().BeTrue();
            result.Value.Name.Should().Be(_Answer.Name);
        }

        [Test]
        public async Task Should_Not_Get_Answer()
        {
            var result = await _service.Get(Guid.NewGuid());
            result.Success.Should().BeTrue();
            result.Value.Should().BeNull();
        }

        [Test]
        public async Task Should_Get_All_Answers()
        {
            var result = await _service.GetAll();
            result.Success.Should().BeTrue();
            result.Value.Count().Should().Be(2);
        }

        [Test]
        public async Task Should_Add_Answer()
        {
            var command = new AddAnswerCommand() {  Name = "TESTE" };

            var result = await _service.Add(command);
            result.Success.Should().BeTrue();
        }

        [Test]
        public async Task Should_Not_Add_Answer()
        {
            var command = new AddAnswerCommand();

            var result = await _service.Add(command);
            result.Success.Should().BeFalse();
            result.Message.Should().Be(AnswerValidationMessages.NAME);
        }

        [Test]
        public async Task Should_Update_Answer()
        {
            var command = new UpdateAnswerCommand()
            {
                Id = _Answer.Id,
                Name = "TESTE"
            };

            var result = await _service.Update(command);
            result.Success.Should().BeTrue();
        }

        [Test]
        public async Task Should_Not_Update_Answer()
        {
            var command = new UpdateAnswerCommand() { Id = _Answer.Id };

            var result = await _service.Update(command);
            result.Success.Should().BeFalse();
            result.Message.Should().Be(AnswerValidationMessages.NAME);
        }

        [Test]
        public async Task Should_Remove_Answer()
        {
            var command = new RemoveAnswerCommand() { Id = _Answer.Id };

            var result = await _service.Delete(command);
            result.Success.Should().BeTrue();
        }

        [Test]
        public async Task Should_Not_Remove_Answer()
        {
            var command = new RemoveAnswerCommand();

            var result = await _service.Delete(command);
            result.Success.Should().BeFalse();
            result.Message.Should().Be(AnswerValidationMessages.ID);
        }
    }
}
