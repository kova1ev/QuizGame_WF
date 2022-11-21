using QuizGame.Domain.Model;
using QuizGame.Domain.Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGame.Domain.Repository
{
    public class EntityRepository : IRepository
    {
        public int Count
        {
            get
            {
                using (var dbcontext = new QuestionContext())
                {
                    return dbcontext.Questions.Count();
                }
            }
        }

        public void Add(Question question)
        {
            using (var dbcontext = new QuestionContext())
            {
                dbcontext.Questions.Add(question);
                dbcontext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var dbcontex = new QuestionContext())
            {
                dbcontex.Questions.Remove(new Question { Id = id });
                dbcontex.SaveChanges();
            }
        }

        public IEnumerable<Question> GetAll()
        {
            using (var dbconext = new QuestionContext())
            {
                return  dbconext.Questions;
            }
        }
        

        public Question GetById(int id)
        {
            using (var dbcontext = new QuestionContext())
            {
                return dbcontext.Questions.FirstOrDefault(q => q.Id == id);
            }
        }

        public void Update(Question question)
        {
            using (var dbcontext = new QuestionContext())
            {
                Question reslut =  GetById(question.Id);
                dbcontext.Update(reslut);
                dbcontext.SaveChanges();
            }
        }
    }
}
