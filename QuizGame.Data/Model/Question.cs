using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuizGame.Domain.Model.Abstract;

namespace QuizGame.Domain.Model
{
    [Table("Questions")]
    public class Question : BaseEntity
    {      
        [Required]
        public string QuestionText { get; private set; }
        [Required]
        public string Answer1 { get; private set; }
        [Required]
        public string Answer2 { get; private set; }
        [Required]
        public string Answer3 { get; private set; }
        [Required]
        public string CorrectAnswer { get; private set; }
        
        public Question(){ }
        public Question (string questionText, string  answer1, string answer2, string answer3,
                            string correctAnswer)
        {
            QuestionText = questionText;
            Answer1 = answer1;
            Answer2 = answer2;
            Answer3 = answer3;
            CorrectAnswer = correctAnswer;
        }
        public override string ToString()
        {
            return $"[{QuestionText} : {CorrectAnswer} - {Answer1} - {Answer2} - {Answer3}]";
        }

    }
}
