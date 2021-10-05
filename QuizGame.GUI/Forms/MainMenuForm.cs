using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuizGame.Data;

namespace QuizGame.GUI
{
    public partial class MainMenuForm : Form 
    {
        private MainFormPresenter presenter;
        public MainMenuForm(MainFormPresenter presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
        }
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                presenter.StartNewGame();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
            //ClickButtonNewGame?.Invoke(this, EventArgs.Empty);           
        }

        private void buttonContinueGame_Click(object sender, EventArgs e)
        {
            try
            {
                presenter.ContinueGame();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {                
            }          
            //ClickButtonContinue?.Invoke(this, EventArgs.Empty);
        }
    }
}
