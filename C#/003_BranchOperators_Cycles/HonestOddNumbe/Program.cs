using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestOddNumbe
{
    internal class Program
    {
        //Задание 1
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число:");
            int number = int.Parse(Console.ReadLine());
            if (number % 2 == 0) Console.WriteLine("Число: " + number + " - четное");
            else Console.WriteLine("Число: " + number + " - нечетное");
            Console.ReadKey();
        }
    }
}
