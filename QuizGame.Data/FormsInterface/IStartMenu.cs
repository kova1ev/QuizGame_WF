using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGame.Data
{
    public interface IStartMenu
    {
        event EventHandler<EventArgs> ClickButtonNewGame;
        event EventHandler<EventArgs> ClickButtonContinue;
    }
}
