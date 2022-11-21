using QuizGame.Domain.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizGame.Domain.Model;

namespace QuizGame.Domain.Repository.Abstract
{
    //CRUD Repository
    public interface IRepository
    {
        Question GetById(int id);
        IEnumerable<Question> GetAll();
        void Add(Question question);
        void Update(Question question);
        void Delete(int id);
        int Count { get; }
    }
}
