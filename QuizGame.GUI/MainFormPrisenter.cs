using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuizGame.Data;

namespace QuizGame.GUI
{
    // убрать перемешивание из сервиса ID
    // выбирать рандомный вопрос
    // получить лист вопросов 
    // получить возможно не весь список вопросов а половину от idlista
    // подумать
    public class MainFormPresenter
    {
        Question Question;
        private List<int> IdList;
        private int idQuestion;
        private readonly IMainForm mainForm;
        public MainFormPresenter() { }

        public MainFormPresenter(IMainForm form)
        {
            mainForm = form;
            mainForm.ClickCheckAnswer += CheckAnswer;
            
        }
        private Question GetNewQuestionOrNull()
        {
            if (IdList.Count > 0)
            {
                IdList.Shufel();
                idQuestion = IdList.ElementAt(IdList.Count - 1); //  аут оф ренж продебажить
                return Question = QuestionService.GetQuestion(idQuestion);
            }
            else return null;
        }


        private void UpdateView(Question question) // вывести вопрос
        {
            // убрать лишнее, метод должен только показывать (обновлять картинку)
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
        public void StartNewGame() //логика началы игры
        {
            IdList = QuestionService.GetIdRangeList();
            UpdateView(GetNewQuestionOrNull());
            // mainForm.ShowButtons();
        }

        public  void ContinueGame() // логика продолжения(загрузки) игры
        {// сделать асинхронным?
            JsonSerializer serializer = new JsonSerializer();
            IdList = serializer.LoadSave();
            //IdList =  await serializer.LoadSaveAsync();
            if (IdList.Count > 0)
            {
                UpdateView(GetNewQuestionOrNull());
                //mainForm.ShowButtons();
            }
            else
            {
                mainForm.GameOver();
            }
        }
        //----------------------------------------------------------------------------------
        void CheckAnswer(object sender, EventArgs e)
        {
            Timer pauseTimer = new Timer();
            pauseTimer.Interval = 1000;
            pauseTimer.Enabled = true;
            pauseTimer.Tick += Timer_Tick;

            Button button = (Button)sender;
            if (button.Text == Question.CorrectAnswer)
            {
                mainForm.RightAnswer(sender);
                pauseTimer.Start();
                IdList.Remove(idQuestion);
                //сохранять асинхронно!
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
