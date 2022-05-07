using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomMatrix
{
    //Задание 1
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Random random = new Random();//Инициализация генератора случайных чисел
            long sumMatrix = 0;//Сумма элементов матрицы

            Console.WriteLine("Введите количество столбцов в матрице:");
            byte columns = byte.Parse(Console.ReadLine());//Количество столбцов
            Console.WriteLine("Введите количество строк в матрице:");
            byte rows = byte.Parse(Console.ReadLine());//Количество строк
            Console.WriteLine();
            int[,] matrix = new int[columns, rows];//Создание в памяти матрицы заданной размерности
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[j, i] = random.Next(int.MinValue, int.MaxValue);//Заполнение элемента матрицы случайным целым числом
                    sumMatrix += matrix[j, i];//Суммирование элементов матрицы
                    Console.Write($"{matrix[j, i]}\t");//Вывод элементов матрицы
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nСумма элементов матрицы: {0}", sumMatrix);//Вывод суммы элементов матрицы
            Console.ReadKey();
        }
    }
}
