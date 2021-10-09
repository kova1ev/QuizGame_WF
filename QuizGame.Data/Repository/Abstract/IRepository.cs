using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizGame.Domain.Repository.Abstract
{
    //CRUD Repository
    public interface IRepositoryAsync<TEntity> 
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity qestion);
        Task UpdateAsync(TEntity qestion);
        Task DeleteAsync(int id);
    }
}
