using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Задание 3. Проверка повторов
Что нужно сделать:
Пользователь вводит число. Число сохраняется в HashSet коллекцию. Если такое число уже присутствует в коллекции, то пользователю на экран выводится сообщение, 
что число уже вводилось ранее. Если числа нет, то появляется сообщение о том, что число успешно сохранено. 
*/

namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int>();
            string numIn;
            do
            {
                Console.WriteLine("Введите число:");
                numIn = Console.ReadLine();
                int num;
                if (numIn.Length != 0) num = int.Parse(numIn);
                else num = 0;
                if (set1.Contains(num))
                {
                    
                    Console.WriteLine("Число уже вводилось ранее!");
                }
                else
                {
                    set1.Add(num);
                    Console.WriteLine("Число успешно сохранено!");
                }
            }
            while (numIn.Length != 0);
        }
    }
}
