using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
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

        public async Task<IEnumerable<Question>> GetAll()
        {
            var query = await GetAllAsync();
            return query.AsEnumerable();
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
    }
}
