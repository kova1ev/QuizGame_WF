using System;
using System.Collections.Generic;
using System.Text;
using QuizGame.Data;

namespace QuizGame.GUI
{
    class StartMenuService
    {
        private IStartMenu MainMenuForm;
        private MainFormService mainFormPresenter;       

        public StartMenuService(IStartMenu mainMenuForm)
        {
            this.mainFormPresenter = new MainFormService();

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
