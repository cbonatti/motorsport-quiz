using FluentAssertions;
using MotorsportQuiz.Core.Commands.Quiz;
using MotorsportQuiz.Core.Services;
using MotorsportQuiz.Core.Validations.Quiz;
using MotorsportQuiz.Core.Validations.Quiz.Messages;
using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Test.Services
{
    [TestFixture]
    public class QuizServiceTest
    {
        private QuizService _service;

        [OneTimeSetUp]
        public void Setup()
        {
            var questions = new List<Question>()
                {
                    new Question(Guid.NewGuid(), "Question 1", new List<QuestionAnswer>() { new QuestionAnswer(Guid.NewGuid(), "", true) }),
                    new Question(Guid.NewGuid(), "Question 2", new List<QuestionAnswer>() { new QuestionAnswer(Guid.NewGuid(), "", true) }),
                    new Question(Guid.NewGuid(), "Question 3", new List<QuestionAnswer>() { new QuestionAnswer(Guid.NewGuid(), "", true) }),
                    new Question(Guid.NewGuid(), "Question 4", new List<QuestionAnswer>() { new QuestionAnswer(Guid.NewGuid(), "", true) }),
                };

            var questionRepo = Substitute.For<IQuestionRepository>();
            questionRepo.GetAll().ReturnsForAnyArgs(questions);

            var validator = new StartQuizCommandValidator();
            _service = new QuizService(questionRepo, validator);
        }

        [Test]
        public async Task Should_Start_Quiz()
        {
            var command = new StartQuizCommand() { UserName = "Carlos" };
            var result = await _service.StartQuiz(command);
            result.Success.Should().BeTrue();
        }

        [Test]
        public async Task Should_Not_Start_Quiz()
        {
            var result = await _service.StartQuiz(new StartQuizCommand());
            result.Success.Should().BeFalse();
            result.Message.Should().Be(QuizValidationMessages.NAME);
        }
    }
}
