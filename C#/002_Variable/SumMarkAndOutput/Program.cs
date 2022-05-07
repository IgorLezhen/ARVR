using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumMarkAndOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fullName = "Лежень Игорь Викторович";//ФИО
            byte age = 28;//Возраст
            string email = "igorl.v.2501@gmail.com";  //Email
            float markProgramming = 9; //Баллы по программированию
            float markMathematics = 8; //Балы по математике
            float markPhysics = 8;//Балы по физике
            float sumMark;//Сумма баллов
            float averageMark;//Среднее арифметическое баллов
            string output;//Вывод

            sumMark = markProgramming + markMathematics + markPhysics;//вычисление суммы баллов
            averageMark = (markProgramming + markMathematics + markPhysics) / 3;//вычисление среднего арифметического баллов

            //Вариант 1
            Console.WriteLine("Вариант 1");
            Console.WriteLine();
            Console.WriteLine("ФИО: " + fullName);
            Console.WriteLine("Возраст: " + age);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Баллы по программированию: " + markProgramming);
            Console.WriteLine("Балы по математике: " + markMathematics);
            Console.WriteLine("Балы по физике: " + markPhysics);
            Console.ReadKey();
            Console.WriteLine("Cумма баллов: " + sumMark.ToString("#.##"));
            Console.ReadKey();
            Console.WriteLine("Среднее арифметическое баллов: " + averageMark.ToString("#.##"));
            Console.WriteLine();
            Console.ReadKey();

            //Остальные варианты вывода понятны как описываются

        }
    }
}
