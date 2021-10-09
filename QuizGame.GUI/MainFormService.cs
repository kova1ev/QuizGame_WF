using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuizGame.Domain;

namespace QuizGame.GUI
{ 
    public class MainFormService
    {
        Timer pauseTimer = new Timer();

        private readonly IQuestionService service;
        private readonly ISerializer serializer;
        private readonly IMainForm mainForm;

        Question Question;
        private List<int> IdList;
        private int idQuestion;


        public MainFormService() { }

        public MainFormService(IMainForm form)
        {
            serializer = new JsonSerializer();
            service = new QuestionService();

            mainForm = form;
            mainForm.ClickCheckAnswer += CheckAnswer;
            pauseTimer.Tick += Timer_Tick;

        }

        private Question GetNewQuestionOrNull()
        {
            if (IdList.Count > 0)
            {
                IdList.Shufel();
                idQuestion = IdList.ElementAt(IdList.Count - 1); 
                return Question = service.Get(idQuestion);
            }
            else return null;
        }


        private void UpdateView(Question question)
        {            
            if (question != null)
            {
                mainForm.QuestionText = question.QuestionText;
                string[] answetTemp = { question.Answer1, question.Answer2, question.Answer3, question.CorrectAnswer };
                answetTemp.Shufel();
                mainForm.Answer1Text = answetTemp[0];
                mainForm.Answer2Text = answetTemp[1];
                mainForm.Answer3Text = answetTemp[2];
                mainForm.Answer4Text = answetTemp[3];
            }
            else
            {
                mainForm.GameOver();
            }
        }
        //----------------------------------------------------------------------------------
        public void StartNewGame() // начало игры
        {
            IdList = service.IdList();
            UpdateView(GetNewQuestionOrNull());
        }

        public  void ContinueGame() // продолжение(загрузка) игры
        {

            IdList = serializer.LoadSave();
            if (IdList.Count > 0)
            {
                UpdateView(GetNewQuestionOrNull());

            }
            else
            {
                mainForm.GameOver();
            }
        }
        //----------------------------------------------------------------------------------
        void CheckAnswer(object sender, EventArgs e)
        {
            pauseTimer.Interval = 1000;
            pauseTimer.Enabled = true;
            Button button = (Button)sender;
            if (button.Text == Question.CorrectAnswer)
            {
                mainForm.RightAnswer(sender);
                pauseTimer.Start();
                IdList.Remove(idQuestion);
                JsonSerializer serializer = new JsonSerializer();
                serializer.SaveAsynk(IdList);                          
            }
            else
            {
                mainForm.WrongAnswer(sender);
                pauseTimer.Start();                
            }
        }

        void Timer_Tick(object sender,EventArgs e)
        {
            Timer pauseTimer = (Timer)sender;
            pauseTimer.Stop();
            UpdateView(GetNewQuestionOrNull());
        }
    }
}
