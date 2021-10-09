using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGame.Domain
{
    public interface ISerializer
    {
        public void Save(List<int> intList);
        public List<int> LoadSave();
       
    }
}
