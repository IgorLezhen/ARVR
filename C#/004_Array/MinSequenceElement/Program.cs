using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinSequenceElement
{
    //Задание 2
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину последовательности:");
            byte length = byte.Parse(Console.ReadLine());//Длина последовательности
            int [] array = new int[length];//Создание в памяти последовательности чисел заданной длины
            Console.WriteLine("Введите элементы последовательности:");
            for (int i = 0; i < length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());//Заполнение последовательности числами
            }
            Console.WriteLine("\nПоследовательность чисел:");
            for (int i = 0; i < length; i++)
            {
                Console.Write($"{array[i]} ");//Вывод элементов последовательности
            }
            int min = array[0];//Переменная минимального значения, по умолчанию присваивается значение первого элемента последовательности
            for (int i = 1;i < length; i++)
            {
                if (array[i] < min) min = array[i];//поиск минимального значения путем сравнения чесле
            }
            Console.WriteLine("\n\nМинимальное значение: {0}", min);//Вывод минимального значения
            Console.ReadKey();
        }
    }
}
