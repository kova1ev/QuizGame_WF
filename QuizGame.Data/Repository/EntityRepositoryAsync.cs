using QuizGame.Domain.Model.Abstract;
using QuizGame.Domain.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Domain.Repository
{
    class EntityRepositoryAsync<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        public Task AddAsync(T qestion)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T qestion)
        {
            throw new NotImplementedException();
        }
    }
}
