using QuizGame.Domain.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizGame.Domain.Model;

namespace QuizGame.Domain.Repository.Abstract
{
    //CRUD Repository
    public interface IRepositoryAsync
    {
        Task<Question> GetByIdAsync(int id);
        Task<IEnumerable<Question>> GetAllAsync();
        Task AddAsync(Question qestion);
        Task UpdateAsync(Question qestion);
        Task DeleteAsync(int id);
    }
}
