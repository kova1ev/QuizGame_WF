using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGame.Domain
{
    public interface IMainForm
    {
        string QuestionText { get; set; }
        string Answer1Text { get; set; }
        string Answer2Text { get; set; }
        string Answer3Text { get; set; }
        string Answer4Text { get; set; }

        event EventHandler<EventArgs> ClickCheckAnswer;

        void RightAnswer(object b);
        void WrongAnswer(object b);

        public void GameOver();
        public void ShowButtons();

    }
}
