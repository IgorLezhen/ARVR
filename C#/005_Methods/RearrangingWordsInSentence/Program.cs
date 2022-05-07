using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RearrangingWordsInSentence
{
    //Задание 2
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            string reverseText = ReversWords(text);//Реверс слов в предложении
            Console.WriteLine(reverseText);//Вывод предложения с обратным порядком слов
            Console.ReadKey();
        }

        /// <summary>
        /// Реверс слов в предложении
        /// </summary>
        /// <param name="text">Введенное предложение</param>
        /// <returns></returns>
        static string ReversWords (string text)
        {
            string[] words = SplittingString(text);
            string reverseText = "";
            for (int i = words.Length-1; i >= 0; i--)
            {
                reverseText += words[i] + " ";
            }
            return reverseText;
        }

        /// <summary>
        /// Разделение строки на слова
        /// </summary>
        /// <param name="text">Введенное предложение</param>
        /// <returns></returns>
        static string[] SplittingString(string text)
        {
            string[] words = text.Split(new char[] { ' ' });
            return words;
        }
    }
}
