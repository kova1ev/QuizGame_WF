using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace QuizGame.Data
{
    public class JsonSerializer
    {
        //private const string userPath = @"../../../UserSave.json";
        private const string userPath = @"UserSave.json";
        public void Save(List<int> list)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<int>));
            using (FileStream fileStream = new FileStream(userPath, FileMode.Create))
            {
                serializer.WriteObject(fileStream, list);
            }
        }

        public List<int> LoadSave()
        {
            List<int> list = new List<int>();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<int>));
            using (FileStream fileStream = new FileStream(userPath, FileMode.Open))
            {
                list = serializer.ReadObject(fileStream) as List<int>;
            }
            return list;
        }

        public async void SaveAsynk(List<int> intList)
        {
             await   Task.Run(()=> Save(intList));
        }

        public async Task<List<int>> LoadSaveAsync()
        {
            return await Task.Run(()=> LoadSave());
        }
    }
}
