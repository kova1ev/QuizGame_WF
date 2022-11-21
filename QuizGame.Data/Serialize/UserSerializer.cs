using System;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using QuizGame.Domain.Model;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace QuizGame.Domain.Serialize
{
    public class UserSerializer : ISerializer
    {
        //private const string userPath = @"../../../UserSave.json";
        private const string userPath = @"UserSave.json";
        public async Task SaveAsync(User user)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            using (FileStream fileStream = new FileStream(userPath, FileMode.Create))
            {
                await JsonSerializer.SerializeAsync<User>(fileStream, user,options);
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

        public bool SerchSave()
        {
            string dir = Directory.GetCurrentDirectory();
            FileInfo saveinfo = new FileInfo(Path.Combine(dir,userPath));
            if (saveinfo.Exists)
                return true;
            return false;
        }

    }
}
