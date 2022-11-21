using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizGame.Domain;
using QuizGame.Domain.Model;
using QuizGame.Domain.Repository.Abstract;
using QuizGame.Domain.Repository;
using QuizGame.Domain.Extantion;

namespace QuizGame.GUI.Service
{
    public class QuestionService : IQuestionService
    {
        IRepository _repository = new EntityRepository();


        public QuestionService() { }
        public QuestionService( EntityRepository entityRepositoryAsync)
        {
            _repository = entityRepositoryAsync;
        }
        


        public IEnumerable<Question> GetAll()
        {
            return  _repository.GetAll();
        }

        public int Count => _repository.Count;


        public List<int> IdList()
        {
            return Enumerable.Range(1, Count).ToList();
        }

        public Question Get(int id)
        {
            return _repository.GetById(id);   
        
        }

        public void Add(Question question)
        {
             _repository.Add(question);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Update(Question question)
        {
            _repository.Update(question);
        }

 
    }
}
