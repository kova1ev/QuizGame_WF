using QuizGame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Domain.Serialize
{
    public interface ISerializer
    {
        public Task<User> LoadSaveAsync();
        public Task SaveAsync(User user);
        bool SerchSave();
    }
}
