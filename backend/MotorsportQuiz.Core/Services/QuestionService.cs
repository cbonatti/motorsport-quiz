using MotorsportQuiz.Core.Commands.Question;
using MotorsportQuiz.Core.Responses;
using MotorsportQuiz.Core.Services.Interfaces;
using MotorsportQuiz.Core.Validations.Question.Interfaces;
using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using MotorsportQuiz.Infra.Results;
using MotorsportQuiz.Infra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Services
{
    public class QuestionService : ValidationServiceBase<QuestionResponse>, IQuestionService
    {
        private readonly IQuestionRepository _repository;
        private readonly IAddQuestionCommandValidator _addQuestionCommandValidator;
        private readonly IUpdateQuestionCommandValidator _updateQuestionCommandValidator;
        private readonly IRemoveQuestionCommandValidator _removeQuestionCommandValidator;

        public QuestionService(IQuestionRepository repository, IAddQuestionCommandValidator addQuestionCommandValidator,
                               IUpdateQuestionCommandValidator updateQuestionCommandValidator, IRemoveQuestionCommandValidator removeQuestionCommandValidator)
        {
            _repository = repository;
            _addQuestionCommandValidator = addQuestionCommandValidator;
            _updateQuestionCommandValidator = updateQuestionCommandValidator;
            _removeQuestionCommandValidator = removeQuestionCommandValidator;
        }

        public async Task<Result<QuestionResponse>> Get(Guid id)
        {
            var query = await _repository.Get(id);
            return new Result<QuestionResponse>(QuestionResponse.ToResponse(query));
        }

        public async Task<Result<IEnumerable<QuestionResponse>>> GetAll()
        {
            var query = await _repository.GetAll();
            var questions = query
                            .OrderBy(question => question.Name)
                            .Select(QuestionResponse.ToResponse)
                            .AsEnumerable();
            return new Result<IEnumerable<QuestionResponse>>(questions);
        }

        public async Task<Result<QuestionResponse>> Add(AddQuestionCommand command)
        {
            var validationResult = Validate(await _addQuestionCommandValidator.Validate(command));
            if (!validationResult.Success)
                return validationResult;

            var question = command.ToQuestion();
            await _repository.Add(question);
            return new Result<QuestionResponse>(new QuestionResponse());
        }

        public async Task<Result<QuestionResponse>> Update(UpdateQuestionCommand command)
        {
            var validationResult = Validate(await _updateQuestionCommandValidator.Validate(command));
            if (!validationResult.Success)
                return validationResult;

            var question = await _repository.Get(command.Id);
            question
                .SetName(command.Name);

            var toAdd = command.Answers
                                .Where(commandAnswer => !question.Answers.Any(answer => answer.AnswerId == commandAnswer.Id))
                                .Select(answer => new QuestionAnswer(answer.Id, answer.Correct))
                                .ToList();
            var toRemove = question.Answers
                                .Where(answer => !command.Answers.Any(commandAnswer => commandAnswer.Id == answer.AnswerId))
                                .ToList();
            var toUpdate = question.Answers
                                .Where(answer => command.Answers.Any(commandAnswer => commandAnswer.Id == answer.AnswerId && commandAnswer.Correct != answer.Correct))
                                .ToList();

            foreach (var item in toRemove)
                question.RemoveAnswer(item);

            foreach (var item in toAdd)
                question.AddAnswer(item);

            foreach (var item in toUpdate)
                item.SetCorrect(!item.Correct);

            await _repository.Update(question);

            return new Result<QuestionResponse>(new QuestionResponse());
        }

        public async Task<Result<QuestionResponse>> Delete(RemoveQuestionCommand command)
        {
            var validationResult = Validate(_removeQuestionCommandValidator.Validate(command));
            if (!validationResult.Success)
                return validationResult;
            await _repository.Remove(command.Id);

            return new Result<QuestionResponse>();
        }
    }
}
