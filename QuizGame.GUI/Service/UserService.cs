using QuizGame.Domain.Serialize;
using QuizGame.Domain.Model;
using QuizGame.Domain.Repository.Abstract;
using QuizGame.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizGame.Domain.Extantion;

namespace QuizGame.GUI.Service
{
    public class UserService
    {
        private readonly ISerializer serialire = new UserSerializer();
        private readonly IRepository repository = new EntityRepository();
        public async Task SaveUserAsync(User user)
        {
            if (user != null)
                await serialire.SaveAsync(user);
            else
                throw new ArgumentNullException("User can not be NULL!");
        }

        public async Task<User> LoadUserAsync()
        {
            return await serialire.LoadSaveAsync();
        }
        
        public User GetUser()
        {
            User user = new User();
            user.IdList = Enumerable.Range(1,repository.Count).ToList();
            user.CurrentQuestion = GetRandomQuestion(user.IdList);
            return user;
        }


        public bool SerchSave()
        {
            return serialire.SerchSave();
        }

        public Question GetRandomQuestion(List<int> idList)
        {
            Question question = null;
            if (idList.Count > 0)
            {
                idList.Shufel();
                var id = idList.ElementAt(idList.Count - 1);
                return repository.GetById(id);
            }
            return question;
        }
    }
}
