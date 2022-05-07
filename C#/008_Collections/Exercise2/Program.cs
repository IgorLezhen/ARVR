using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Задание 2.Телефонная книга
Что нужно сделать:
1 Пользователю итеративно предлагается вводить в программу номера телефонов и ФИО их владельцев. 
2 В процессе ввода информация размещается в Dictionary, где ключом является номер телефона, а значением — ФИО владельца. 
  Таким образом, у одного владельца может быть несколько номеров телефонов. Признаком того, что пользователь закончил вводить номера телефонов, является ввод пустой строки. 
3 Далее программа предлагает найти владельца по введенному номеру телефона. Пользователь вводит номер телефона и ему выдаётся ФИО владельца. 
  Если владельца по такому номеру телефона не зарегистрировано, программа выводит на экран соответствующее сообщение.
*/

namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<string, string>();
            string num, fio;
            do
            {
                Console.WriteLine("Введите номер телефона:");
                num = Console.ReadLine();
                Console.WriteLine("Введите ФИО владельца телефона:");
                fio = Console.ReadLine();
                phoneBook.Add(num, fio);

            }
            while (num.Length != 0 && fio.Length != 0);
            PrintToConsole(phoneBook);
            Console.ReadKey();
        }

        /// <summary>
        /// Поиск владельца телефона
        /// </summary>
        /// <param name="phoneBook">Телефонная книга</param>
        static void PrintToConsole(Dictionary<string, string> phoneBook)
        {
            Console.WriteLine("Введите номер телефона абонента:");
            string num = Console.ReadLine();
            if (phoneBook.TryGetValue(num, out string fio))
            {
                Console.WriteLine("Найдено! Телефон: {0}, Владелец: {1}", num, fio);
            }
            else Console.WriteLine("Номер телефона не зарегистрирован!");
        }

    }
}
