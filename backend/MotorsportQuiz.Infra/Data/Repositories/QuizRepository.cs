using MotorsportQuiz.Domain;
using MotorsportQuiz.Infra.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportQuiz.Infra.Data.Repositories
{
    public class QuizRepository : RepositoryAsync<Quiz>, IQuizRepository
    {
        public QuizRepository(MotorsportQuizDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Quiz>> GetAll()
        {
            var query = await GetAllAsync();
            return query.AsEnumerable();
        }

        public async Task<Quiz> Add(Quiz quiz) => await AddAsync(quiz);
    }
}
