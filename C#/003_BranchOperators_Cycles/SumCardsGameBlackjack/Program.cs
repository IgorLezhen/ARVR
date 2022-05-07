using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumCardsGameBlackjack
{
    internal class Program
    {
        //Задание 2
        static void Main(string[] args)
        {
            Console.WriteLine("Игра Blackjack");
            Console.WriteLine("Обозначения карт: \nВалет - J \nДама - Q \nКороль - K \nТуз - T");
            Console.WriteLine("\nСколько карт у вас на руках:");
            byte sumCards = byte.Parse(Console.ReadLine());//количество карт на руках
            UInt16 sum = 0;//переменная суммы карт
            //Определение суммы карт
            for (int i = 1; i <= sumCards; i++)
            {
                Console.WriteLine("Введите " + i + " карту");
                string card = Console.ReadLine();//ввод значений веса карт
                //суммирование согласно весу карт
                switch (card)
                {
                    case "6": sum += 6; break;
                    case "7": sum += 7; break;
                    case "8": sum += 8; break;
                    case "9": sum += 9; break;
                    case "10": sum += 10; break;
                    case "J": sum += 10; break;
                    case "Q": sum += 10; break;
                    case "K":sum += 10; break;
                    case "T":sum += 10; break;
                    default: Console.WriteLine("Недопустимое значение"); i--; break; //карта имеет недопустимое значение и возврат индекса цикла на текущую карту
                }
            }
            //вывод суммы карт на руках
            Console.WriteLine($"\nСумма карт: {sum}");
            Console.ReadKey();
        }
    }
}
