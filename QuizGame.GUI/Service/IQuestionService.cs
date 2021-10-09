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
        IEnumerable<Question> Questions { get; }
        int Count { get; }
        List<int> IdList();
        Question Get(int id);

        void Create(Question qestion);
        void Update(Question qestion);
        void Delete(int id);
    }
}
