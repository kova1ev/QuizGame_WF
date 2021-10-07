using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGame.Data
{
    public class QuestionService : IQuestionService
    {

        //public static List<int> GetIdRangeList()
        //{
        //    int countQestions = QuestionsCount();
        //    int[] temp = new int[countQestions];
        //    for (int i = 0; i < countQestions; i++) temp[i] = i+1;
        //    return temp.ToList(); ;
        //}

        //public static  Question GetQuestion(int Id)
        //{
        //    Question question = null;
        //    using(var db = new QuestionContext())
        //    {
        //        question = db.Questions.Find(Id);
        //    }
        //    return question;
        //}

        //public static int QuestionsCount()
        //{
        //    using(var db = new QuestionContext())
        //    {
        //        return db.Questions.Count();
        //    }           
        //}
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
