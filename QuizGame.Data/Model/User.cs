using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Domain.Model
{

    public class User
    {
        public int Score { get; set; } = 0;
        public List<int> IdList { get; set; }
        public Question CurrentQuestion {get;set;}
    }
}
