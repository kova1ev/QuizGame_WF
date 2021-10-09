using QuizGame.Domain.Model.Abstract;
using QuizGame.Domain.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Domain.Repository
{
public class EntityRepositoryAsync : IRepositoryAsync
    {
        public async Task AddAsync(Question qestion)
        {
            using (var dbcontext = new QuestionContext())
            {
                dbcontext.Questions.Add(qestion);
                await Task.Run(()=>dbcontext.SaveChanges());              
            }
        }

        public async Task DeleteAsync(int id)
        {
            using(var dbcontex= new QuestionContext())
            {
                dbcontex.Questions.Remove(new Question { Id = id });
                await Task.Run(()=>dbcontex.SaveChanges());
            }
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            using(var dbconext = new QuestionContext())
            {
                var list = await Task.Run(()=> dbconext.Questions.ToList());
                return list;
            }
        }
        public  IEnumerable<Question> GetAll()
        {
            var dbconext = new QuestionContext();
           
                var list =  dbconext.Questions;
                return list;
            
        }

        public Task<Question> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Question qestion)
        {
            throw new NotImplementedException();
        }
    }
}
