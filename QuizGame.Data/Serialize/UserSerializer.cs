using System;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using QuizGame.Domain.Model;

namespace QuizGame.Domain
{
    public class UserSerializer : ISerializer
    {
        //private const string userPath = @"../../../UserSave.json";
        private const string userPath = @"UserSave.json";
        public async Task SaveAsync(User user)
        {
            using (FileStream fileStream = new FileStream(userPath, FileMode.Create))
            {
                await JsonSerializer.SerializeAsync<User>(fileStream, user);
            }
        }

        public async Task<User> LoadSaveAsync()
        {
            using (FileStream fileStream = new FileStream(userPath, FileMode.Open))
            {
                User user = await JsonSerializer.DeserializeAsync<User>(fileStream);
                return user;
            }
        }

    }
}
