using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Random r = new Random();
            for (int i = 1; i <= 101; i++)
            {
                list.Add(r.Next(101));
            }
            Console.WriteLine("100 случайных чисел от 0 до 100");
            Console.WriteLine();
            Print(list);
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Удалены числа от 25 до 50");
            Console.WriteLine();
            DeleteNumber(list);
            Print(list);
            Console.WriteLine();
            Console.ReadKey();

        }

        /// <summary>
        /// Вывод в консоль листа чисел
        /// </summary>
        /// <param name="list">Лист чисел</param>
        static void Print(List<int> list)
        {
            for (int i = 1; i < list.Count; i++) Console.Write($"{list[i]} ");
            
        }

        /// <summary>
        /// Удаление чисел от 25 до 50
        /// </summary>
        /// <param name="list">Лист чисел</param>
        /// <returns></returns>
        static List<int> DeleteNumber(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (25 <= list[i] && list[i] <= 50)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
                return list; 
        }


    }
}
