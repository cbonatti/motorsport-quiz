using MotorsportQuiz.Core.Commands.Answer;
using MotorsportQuiz.Core.Responses;
using MotorsportQuiz.Core.Services.Interfaces;
using MotorsportQuiz.Core.Validations.Answer.Interfaces;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using MotorsportQuiz.Infra.Results;
using MotorsportQuiz.Infra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportQuiz.Core.Services
{
    public class AnswerService : ValidationServiceBase<AnswerResponse>, IAnswerService
    {
        private readonly IAnswerRepository _repository;
        private readonly IAddAnswerCommandValidator _addAnswerCommandValidator;
        private readonly IUpdateAnswerCommandValidator _updateAnswerCommandValidator;
        private readonly IRemoveAnswerCommandValidator _removeAnswerCommandValidator;

        public AnswerService(IAnswerRepository repository, IAddAnswerCommandValidator addAnswerCommandValidator,
                               IUpdateAnswerCommandValidator updateAnswerCommandValidator, IRemoveAnswerCommandValidator removeAnswerCommandValidator)
        {
            _repository = repository;
            _addAnswerCommandValidator = addAnswerCommandValidator;
            _updateAnswerCommandValidator = updateAnswerCommandValidator;
            _removeAnswerCommandValidator = removeAnswerCommandValidator;
        }

        public async Task<Result<AnswerResponse>> Get(Guid id)
        {
            var query = await _repository.Get(id);
            return new Result<AnswerResponse>(AnswerResponse.ToResponse(query));
        }

        public async Task<Result<IEnumerable<AnswerResponse>>> GetAll()
        {
            var query = await _repository.GetAll();
            var Answers = query
                            .OrderBy(x => x.Name)
                            .Select(AnswerResponse.ToResponse)
                            .AsEnumerable();
            return new Result<IEnumerable<AnswerResponse>>(Answers);
        }

        public async Task<Result<AnswerResponse>> Add(AddAnswerCommand command)
        {
            var validationResult = Validate(await _addAnswerCommandValidator.Validate(command));
            if (!validationResult.Success)
                return validationResult;

            var Answer = command.ToAnswer();

            await _repository.Add(Answer);

            return new Result<AnswerResponse>(AnswerResponse.ToResponse(Answer));
        }

        public async Task<Result<AnswerResponse>> Update(UpdateAnswerCommand command)
        {
            var validationResult = Validate(await _updateAnswerCommandValidator.Validate(command));
            if (!validationResult.Success)
                return validationResult;

            var Answer = await _repository.Get(command.Id);
            Answer
                .SetName(command.Name);

            await _repository.Update(Answer);

            return new Result<AnswerResponse>(AnswerResponse.ToResponse(Answer));
        }

        public async Task<Result<AnswerResponse>> Delete(RemoveAnswerCommand command)
        {
            var validationResult = Validate(_removeAnswerCommandValidator.Validate(command));
            if (!validationResult.Success)
                return validationResult;
            await _repository.Remove(command.Id);

            return new Result<AnswerResponse>();
        }
    }
}
