using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGame.Data
{
    public interface ISerializer
    {
        public void Save(List<int> intList);
        public List<int> LoadSave();
       
    }
}
