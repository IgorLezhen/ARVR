using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplittingStringIntoWords
{
    //Задание 1
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            string[] words = SplittingString(text);//Формирование массива слов в методе SplittingString
            PrintWords(words);//Вывод массива слов в методе  PrintWords
            Console.ReadKey();
        }
        /// <summary>
        /// Разделение строки на слова
        /// </summary>
        /// <param name="text">Введенное предложение</param>
        /// <returns></returns>
        static string[] SplittingString (string text)
        {
            string[] words = text.Split(new char[] { ' ' });
            return words;        
        }
        /// <summary>
        /// Вывод слов в новой строке
        /// </summary>
        /// <param name="words">Массив слов предложения</param>
        static void PrintWords (string [] words)
        {
            foreach (var e in words) Console.WriteLine(e);
        }
    }
}
