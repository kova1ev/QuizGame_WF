using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizGame.Domain;
using QuizGame.Domain.Model;
using QuizGame.Domain.Repository.Abstract;
using QuizGame.Domain.Repository;
using QuizGame.Domain.Extantion;

namespace QuizGame.GUI
{
    public class QuestionService : IQuestionService
    {
        IRepositoryAsync _repository;
        public QuestionService( EntityRepositoryAsync entityRepositoryAsync)
        {
            _repository = entityRepositoryAsync;
        }
        
        public async Task<IEnumerable<Question>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public int Count
        {
            get
            {
                return GetAll().Result.Count();
            }
        }

        public List<int> IdList()
        {
            return Enumerable.Range(1, Count).ToList();
        }

        public async Task<Question> Get(int id)
        {
            return await _repository.GetByIdAsync(id);   
        
        }

        public async Task Add(Question question)
        {
            await _repository.AddAsync(question);
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task Update(Question question)
        {
            await _repository.UpdateAsync(question);
        }


        public async Task<Question> GetRandomQuestion() 
        {
            Question question = null;
            if (IdList.Count > 0)
            {
                IdList.Shufel();
                idQuestion = IdList.ElementAt(IdList.Count - 1);
                return question = service.Get(idQuestion);
            }
            return question;     
        } 
    }
}
