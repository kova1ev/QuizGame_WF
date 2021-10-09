using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizGame.Domain;
using QuizGame.Domain.Model;
using QuizGame.Domain.Repository.Abstract;
using QuizGame.Domain.Repository;

namespace QuizGame.GUI
{
    public class QuestionService : IQuestionService
    {
        IRepositoryAsync repositoryAsync;
        public QuestionService( EntityRepositoryAsync entityRepositoryAsync)
        {
            repositoryAsync = entityRepositoryAsync;
        }
        public IEnumerable<Question> Questions
        {
            get
            {
                using (var context = new QuestionContext())
                {
                    return context.Questions;
                }
            }
        }

        public int Count
        {
            get
            {
                using (var context = new QuestionContext())
                {
                    return context.Questions.Count();
                }
            }
        }

        public List<int> IdList()
        {
            return Enumerable.Range(1, Count).ToList();
        }

        public Question Get(int id)
        {
            using (var context = new QuestionContext())
            {
                return context.Questions.FirstOrDefault(q => q.Id == id);
            }
        }

        //----------------------------------//
        public void Create(Question qestion)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Question qestion)
        {
            throw new NotImplementedException();
        }
    }
}
