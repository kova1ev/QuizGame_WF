using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuizGame.Domain.Extantion;
using QuizGame.Domain.Model;
using QuizGame.GUI.Service;

namespace QuizGame.GUI
{
    public partial class MainForm : Form
    {
        private readonly Timer pauseTimer = new Timer();

        // заменить на интерфейсы
        private User user;
        private readonly UserService userService;
        public MainForm()
        {
            userService = new UserService();
            // user = new User();

            InitializeComponent();
            pauseTimer.Tick += Timer_Tick;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            StartGame();

        }
        //----------------------------------------------------//
        async void buttonsAnswer_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            pauseTimer.Interval = 1000;
            pauseTimer.Enabled = true;

            if (button.Text == user.CurrentQuestion.CorrectAnswer)
            {
                RightAnswer(sender);
                pauseTimer.Start();
                user.IdList.Remove(user.CurrentQuestion.Id); //
                 //  убрать в сервис
            }
            else
            {
                WrongAnswer(sender);
                pauseTimer.Start();
            }
            user.CurrentQuestion = userService.GetRandomQuestion(user.IdList);
            await userService.SaveUserAsync(user);
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            Timer pauseTimer = (Timer)sender;
            pauseTimer.Stop();
            UpdateView(user);
        }

        public void UpdateView(User user)
        {
            if (user.CurrentQuestion != null)
            {
                label_QuestionText.Text = user.CurrentQuestion.QuestionText;
                string[] answetTemp = {
                        user.CurrentQuestion.Answer1,
                        user.CurrentQuestion.Answer2,
                        user.CurrentQuestion.Answer3,
                        user.CurrentQuestion.CorrectAnswer 
                };
                answetTemp.Shufel();
                button1.Enabled = true;
                button1.BackColor = SystemColors.ControlLight;
                button2.Enabled = true;
                button2.BackColor = SystemColors.ControlLight;
                button3.Enabled = true;
                button3.BackColor = SystemColors.ControlLight;
                button4.Enabled = true;
                button4.BackColor = SystemColors.ControlLight;
                button1.Text = answetTemp[0];
                button2.Text = answetTemp[1];
                button3.Text = answetTemp[2];
                button4.Text = answetTemp[3];
            }
            else
            {
                GameOver();
            }
        }
        //----------------------------------------------------------------------------------
        private void NewGame() // начало игры
        {

        }

        private async void StartGame() // продолжение(загрузка) игры
        {
            try
            {
                if (!userService.SerchSave())
                {
                    user = userService.GetUser();
                    await userService.SaveUserAsync(user);
                }
                else
                {
                    user = await userService.LoadUserAsync();
                }
                UpdateView(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
