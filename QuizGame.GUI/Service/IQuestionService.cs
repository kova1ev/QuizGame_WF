using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizGame.Domain.Model;

namespace QuizGame.GUI.Service
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAll();
        int Count { get; }
        List<int> IdList();
        Question Get(int id);
        void Add(Question qestion);
        void Delete(int id);
        void Update(Question qestion);

    }
}
