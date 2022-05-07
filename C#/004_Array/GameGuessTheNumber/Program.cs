using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuessTheNumber
{
    //Задание 3
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите максимальное число диапазона:");
            byte max = byte.Parse(Console.ReadLine());//Ввод максимального значения до 255
            Console.WriteLine($"\nДиапазон чисел: 0 - {max}");//Отображение диапазона чисел
            Random random = new Random();//Инициализация генератора случайных чисел
            int number = random.Next(0,max+1);//Генерация случайного числа из заданного диапазона чисел
            while(true)
            {
                Console.WriteLine("\nВведите число из диапазона:");
                string num = Console.ReadLine();//Ввод числа 
                if (num == "") { Console.WriteLine($"\nЗагаданное число: {number}"); break; }//Вывод загаданного числа, если строка пустая (надоело играть)
                if (int.Parse(num) < number) Console.WriteLine("Число меньше загаданного");//Вывод, если число меньше загаданного
                else if (int.Parse(num) > number) Console.WriteLine("Число больше загаданного");//Вывод, если число больше загаданного
                else { Console.WriteLine($"Угадали!\nЗагаданное число: {number}"); break; }//Вывод, если число угадано
            }
            Console.ReadKey();
        }
    }
}
