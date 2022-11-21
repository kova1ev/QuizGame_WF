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
        public string QuestionText { get;  set; }
        [Required]
        public string Answer1 { get;  set; }
        [Required]
        public string Answer2 { get;  set; }
        [Required]
        public string Answer3 { get;  set; }
        [Required]
        public string CorrectAnswer { get;set; }       
    }
}
