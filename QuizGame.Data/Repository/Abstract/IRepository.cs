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
        Task AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(int id);
    }
}
