using QuizGame.Domain.Model.Abstract;
using QuizGame.Domain.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizGame.Domain.Model;

namespace QuizGame.Domain.Repository
{
public class EntityRepositoryAsync : IRepositoryAsync
    {
        public async Task AddAsync(Question question)
        {
            using (var dbcontext = new QuestionContext())
            {
                dbcontext.Questions.Add(question);
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
                return await Task.Run(()=>dbconext.Questions);
            }
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            using(var dbcontext = new QuestionContext())
            {
                return await Task.Run(()=>dbcontext.Questions.FirstOrDefault(q => q.Id == id));
            }
        }

        public async Task UpdateAsync(Question question)
        {
            using (var dbcontext = new QuestionContext())
            {
                Question reslut = await GetByIdAsync(question.Id);
                dbcontext.Update(reslut);
                await Task.Run(()=> dbcontext.SaveChanges());
            }
        }
    }
}
