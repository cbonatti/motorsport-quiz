using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
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

        public async Task<IEnumerable<Answer>> GetAll()
        {
            var query = await GetAllAsync();
            return query.AsEnumerable();
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
    }
}
