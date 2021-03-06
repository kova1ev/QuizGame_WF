using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Data
{
    interface IQuestionService
    {
        void Create(Question qestion);
        IEnumerable<Question> Questions { get; }

        void Update(Question qestion);
        void Delete(int id);


    }
}
