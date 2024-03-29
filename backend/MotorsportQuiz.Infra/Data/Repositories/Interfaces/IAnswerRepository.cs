﻿using MotorsportQuiz.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportQuiz.Infra.Data.Repositories.Interfaces
{
    public interface IAnswerRepository
    {
        Task<Answer> Get(Guid id);
        Task<IEnumerable<Answer>> GetAll();
        Task<bool> VerifyExistence(string name, Guid? id);
        Task<Answer> Add(Answer answer);
        Task<Answer> Update(Answer answer);
        Task<Answer> Remove(Answer answer);
        Task Remove(Guid id);
    }
}
