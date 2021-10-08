using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizGame.Data.Model.Abstract;

namespace QuizGame.Data.Repository.Abstract
{
    //CRUD Repository
    public interface IRepositoryAsync<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity qestion);
        Task UpdateAsync(TEntity qestion);
        Task DeleteAsync(int id);
    }
}
