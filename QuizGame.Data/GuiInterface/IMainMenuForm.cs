using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGame.Data
{
    public interface IMainMenuForm
    {
        event EventHandler<EventArgs> ClickButtonNewGame;
        event EventHandler<EventArgs> ClickButtonContinue;
    }
}
