using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportQuiz.Infra.Data.Repositories
{
    public class AnswerRepository : RepositoryAsync<Answer>, IAnswerRepository
    {
        public AnswerRepository(MotorsportQuizDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Answer> Get(Guid id) => await GetByIdAsync(id);

        public async Task<IEnumerable<Answer>> GetAll()
        {
            var query = await GetAllAsync();
            return query.AsEnumerable();
        }

        public async Task<bool> VerifyExistence(string name, Guid? id)
        {
            var query = await GetAllAsync();
            query = query.Where(answer => answer.Name.Equals(name));
            if (id.HasValue)
                query = query.Where(answer => !answer.Id.Equals(id.Value));
            return query.Any();
        }

        public async Task<Answer> Add(Answer answer) => await AddAsync(answer);

        public async Task<Answer> Update(Answer answer)
        {
            await UpdateAsync(answer);
            return answer;
        }

        public async Task<Answer> Remove(Answer answer)
        {
            await RemoveAsync(answer);
            return answer;
        }

        public async Task Remove(Guid id)
        {
            await RemoveAsync(id);
        }
    }
}
