using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuizGame.Domain;

namespace QuizGame.GUI
{
    public partial class StartMenuForm : Form 
    {
        private MainFormService presenter;
        public StartMenuForm(MainFormService presenter)
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
                     

        }
    }
}
