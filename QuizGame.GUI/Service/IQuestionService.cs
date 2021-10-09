using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizGame.Domain.Model;

namespace QuizGame.GUI
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAll();
        int Count { get; }
        List<int> IdList();
        Task<Question> Get(int id);
        Task Add(Question qestion);
        Task Delete(int id);
        Task Update(Question qestion);
    }
}
