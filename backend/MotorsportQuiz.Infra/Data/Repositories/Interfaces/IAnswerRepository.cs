using MotorsportQuiz.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportQuiz.Infra.Data.Repositories.Interfaces
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<Answer>> GetAll();
        Task<Answer> Add(Answer answer);
        Task<Answer> Update(Answer answer);
        Task<Answer> Remove(Answer answer);
    }
}
