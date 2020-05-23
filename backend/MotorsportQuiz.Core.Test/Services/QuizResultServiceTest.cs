using FluentAssertions;
using MotorsportQuiz.Core.Commands.Quiz;
using MotorsportQuiz.Core.Commands.Quiz.Contracts;
using MotorsportQuiz.Core.Services;
using MotorsportQuiz.Core.Validations.Quiz;
using MotorsportQuiz.Core.Validations.Quiz.Messages;
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
    public class QuizResultServiceTest
    {
        private QuizResultService _service;
        private Guid _question1Id = Guid.NewGuid();
        private Guid _question2Id = Guid.NewGuid();
        private Guid _question3Id = Guid.NewGuid();
        private Guid _question4Id = Guid.NewGuid();
        private Guid _answer1Id = Guid.NewGuid();
        private Guid _answer2Id = Guid.NewGuid();
        private Guid _answer3Id = Guid.NewGuid();
        private Guid _answer4Id = Guid.NewGuid();

        [OneTimeSetUp]
        public void Setup()
        {
            var questions = new List<Question>()
                {
                    new Question(_question1Id, "", new List<QuestionAnswer>() { new QuestionAnswer(_answer1Id, "", true) }),
                    new Question(_question2Id, "", new List<QuestionAnswer>() { new QuestionAnswer(_answer2Id, "", true) }),
                    new Question(_question3Id, "", new List<QuestionAnswer>() { new QuestionAnswer(_answer3Id, "", true) }),
                    new Question(_question4Id, "", new List<QuestionAnswer>() { new QuestionAnswer(_answer4Id, "", true) }),
                };

            var questionRepo = Substitute.For<IQuestionRepository>();
            questionRepo.GetAll(Arg.Any<List<Guid>>()).ReturnsForAnyArgs(questions);

            var quizRepo = Substitute.For<IQuizRepository>();
            quizRepo.GetAll().ReturnsForAnyArgs(new List<Quiz>() {
                new Quiz("Carlos", 50),
                new Quiz("Gabriela", 50),
                new Quiz("Enrico", 100),
            });

            var validator = new FinishQuizCommandValidator();
            _service = new QuizResultService(quizRepo, questionRepo, validator);
        }

        [Test]
        public async Task Should_Get_All_Questions()
        {
            var result = await _service.GetAll();
            result.Success.Should().BeTrue();
            result.Value.Count().Should().Be(3);
            result.Value.First().Name.Should().Be("Enrico");
            result.Value.Last().Name.Should().Be("Gabriela");
        }

        [Test]
        public async Task Should_Finish_Quiz()
        {
            var command = new FinishQuizCommand()
            {
                UserName = "Carlos",
                Answers = new List<QuizAnswerDto>()
                {
                    new QuizAnswerDto() { QuestionId = _question1Id, AnswerId = _answer1Id },
                    new QuizAnswerDto() { QuestionId = _question2Id, AnswerId = _answer2Id },
                    new QuizAnswerDto() { QuestionId = _question3Id, AnswerId = _answer3Id },
                    new QuizAnswerDto() { QuestionId = _question4Id, AnswerId = _answer4Id },
                }
            };

            var result = await _service.FinishQuiz(command);
            result.Success.Should().BeTrue();
        }

        [Test]
        public async Task Should_Not_Finish_Quiz()
        {
            var result = await _service.FinishQuiz(new FinishQuizCommand());
            result.Success.Should().BeFalse();
            result.Message.Should().Be(QuizValidationMessages.NAME);
        }

        [Test]
        public async Task Should_Calculate_Quiz_Result_50_Percent()
        {
            var command = new FinishQuizCommand()
            {
                UserName = "Carlos",
                Answers = new List<QuizAnswerDto>()
                {
                    new QuizAnswerDto() { QuestionId = _question1Id, AnswerId = _answer1Id },
                    new QuizAnswerDto() { QuestionId = _question2Id, AnswerId = _answer1Id },
                    new QuizAnswerDto() { QuestionId = _question3Id, AnswerId = _answer1Id },
                    new QuizAnswerDto() { QuestionId = _question4Id, AnswerId = _answer4Id },
                }
            };
            var result = await _service.CalculateResult(command);
            result.Should().Be(50);
        }

        [Test]
        public async Task Should_Calculate_Quiz_Result_75_Percent()
        {
            var command = new FinishQuizCommand()
            {
                UserName = "Carlos",
                Answers = new List<QuizAnswerDto>()
                {
                    new QuizAnswerDto() { QuestionId = _question1Id, AnswerId = _answer1Id },
                    new QuizAnswerDto() { QuestionId = _question2Id, AnswerId = _answer1Id },
                    new QuizAnswerDto() { QuestionId = _question3Id, AnswerId = _answer3Id },
                    new QuizAnswerDto() { QuestionId = _question4Id, AnswerId = _answer4Id },
                }
            };
            var result = await _service.CalculateResult(command);
            result.Should().Be(75);
        }
    }
}
