using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNumber
{
    internal class Program
    {
        //Задание 3
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число:");
            int number = int.Parse(Console.ReadLine());//ввод числа
            bool buf = false;//флаг простого числа 
            Int32 i = 2;//переменная счетчика итераций
            if (number > 0) //проверка является ли число натуральным
            {
                while (i < number)
                {
                    if (number % i == 0) buf = true; //если остаток от деления равен 0, то меняется флаг простого числа
                    i++;
                }
                //вывод является ли число простым или нет
                if (buf == false) Console.WriteLine("Число является простым");
                else Console.WriteLine("Число не является простым");
            }
            else Console.WriteLine("Число не является натуральным!");
            Console.ReadKey();
        }
    }
}
