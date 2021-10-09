using System;

namespace QuizGame.Domain.Extantion
{ 
    public static class ArrayExtension
    {
        public static void Shufel<T>(this T[] array)
        {
            Random random = new Random();
            for(int i = array.Length-1; i>=1;i--)
            {
                int j = random.Next(i + 1);
                T s = array[j];
                array[j] = array[i];
                array[i] = s;
            }
        }
    }
}
