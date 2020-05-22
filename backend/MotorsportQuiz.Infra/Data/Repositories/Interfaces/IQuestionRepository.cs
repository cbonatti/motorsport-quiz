using MotorsportQuiz.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportQuiz.Infra.Data.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAll();
        Task<bool> VerifyExistence(string name, Guid? id);
        Task<Question> Add(Question question);
        Task<Question> Update(Question question);
        Task<Question> Remove(Question question);
    }
}
