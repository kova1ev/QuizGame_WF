using System;
using System.Collections.Generic;

namespace QuizGame.Domain.Extantion
{
    public static class ListExtension
    {
        public static void Shufel<T>(this List<T> list)
        {
            Random random = new Random();
            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                T s = list[j];
                list[j] = list[i];
                list[i] = s;
            }
        }
    }
}
