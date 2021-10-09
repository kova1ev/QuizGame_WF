using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Domain
{
    public interface ISerializer
    {
        public void Save(List<int> intList);
        public List<int> LoadSave();
        public Task<List<int>> LoadSaveAsync();
        public void SaveAsync(List<int> intList);
    }
}
