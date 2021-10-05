using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGame.Data
{
    interface ISerializer
    {
        public void Save(List<int> intList);
        public List<int> LoadSave();
       
    }
}
