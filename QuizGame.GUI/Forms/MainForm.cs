using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuizGame.Domain;


namespace QuizGame.GUI
{
    public partial class MainForm : Form, IMainForm
    {
        #region
        public string QuestionText
        {
            get => label_QuestionText.Text;
            set => label_QuestionText.Text = value;
        }
        public string Answer1Text
        {
            get => button1.Text;
            set
            {
                button1.Text = value;
                button1.Enabled = true;
                button1.BackColor = SystemColors.ControlLight;
            }
        }
        public string Answer2Text
        {
            get => button2.Text;
            set
            {
                button2.Text = value;
                button2.Enabled = true;
                button2.BackColor = SystemColors.ControlLight;
            }
        }
        public string Answer3Text
        {
            get => button3.Text;
            set
            {
                button3.Text = value;
                button3.Enabled = true;
                button3.BackColor = SystemColors.ControlLight;
            }
        }
        public string Answer4Text
        {
            get => button4.Text;
            set
            {
                button4.Text = value;
                button4.Enabled = true;
                button4.BackColor = SystemColors.ControlLight;
            }
        }
        #endregion

        public MainFormService presenter;

        public event EventHandler<EventArgs> ClickCheckAnswer; //////  <----

        public MainForm()
        {
            InitializeComponent();
            presenter = new MainFormService(this);
        }

        void Form1_Load(object sender, EventArgs e)
        {
           ShowChildForm(new StartMenuForm(presenter));
        }
        private void ShowChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        void buttonsAnswer_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ClickCheckAnswer?.Invoke(button, EventArgs.Empty);
        }

        //----------------------------------------------------------------------------------
        public void GameOver()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            label_QuestionText.Text = "GAME OVER!";
        }

        public void ShowButtons()
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        public void RightAnswer(object b)
        {
            Button button = (Button)b;
            button.BackColor = Color.Green;
            LockButton();
        }

        public void WrongAnswer(object b)
        {
            Button button = (Button)b;
            button.BackColor = Color.Red;
            LockButton();
        }
        private void LockButton()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }


    }
}
