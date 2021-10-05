using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.GUI.ViewModel
{
    class QuetionViewModel
    {
        //todo организовать валидацию
        public string QuestionText { get; private set; }
        public string Answer1 { get; private set; }
        public string Answer2 { get; private set; }
        public string Answer3 { get; private set; }
        public string CorrectAnswer { get; private set; }
    }
}
