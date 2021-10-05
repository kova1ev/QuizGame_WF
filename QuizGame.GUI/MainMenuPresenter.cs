using System;
using System.Collections.Generic;
using System.Text;
using QuizGame.Data;

namespace QuizGame.GUI
{
    class MainMenuPresenter
    {
        private IMainMenuForm MainMenuForm;
        private MainFormPresenter mainFormPresenter;       

        public MainMenuPresenter(IMainMenuForm mainMenuForm)//,MainFormPresenter mainFormPresenter)
        {
            this.mainFormPresenter = new MainFormPresenter();
            this.MainMenuForm = mainMenuForm;
            MainMenuForm.ClickButtonNewGame += StartNewGame;
            mainMenuForm.ClickButtonContinue += ContinueGame;              
        }

        private void StartNewGame(object sender, EventArgs e)
        {
            mainFormPresenter.StartNewGame();
        }
        private void ContinueGame(object sender, EventArgs e)
        {
            mainFormPresenter.ContinueGame();
        }

    }
}
