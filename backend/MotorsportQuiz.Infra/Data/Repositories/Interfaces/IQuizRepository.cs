using MotorsportQuiz.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportQuiz.Infra.Data.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetAll();
        Task<Quiz> Add(Quiz quiz);
    }
}
