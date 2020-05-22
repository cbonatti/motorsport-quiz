using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportQuiz.Infra.Data.Repositories
{
    public class QuestionRepository : RepositoryAsync<Question>, IQuestionRepository
    {
        public QuestionRepository(MotorsportQuizDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Question> Get(Guid id) => await GetByIdAsync(id);

        public async Task<IEnumerable<Question>> GetAll()
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

        public async Task<Question> Add(Question question) => await AddAsync(question);

        public async Task<Question> Update(Question question)
        {
            await UpdateAsync(question);
            return question;
        }

        public async Task<Question> Remove(Question question)
        {
            await RemoveAsync(question);
            return question;
        }

        public async Task Remove(Guid id)
        {
            await RemoveAsync(id);
        }
    }
}
