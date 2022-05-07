using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReferenceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Справочник «Сотрудники»");
            Console.WriteLine("Для просмотра данных справочника введите 1");
            Console.WriteLine("Для заполнения новыми данными введите 2");
            Console.WriteLine("Ваш выбор:");
            string num = Console.ReadLine();
            string nameFile = "worker.txt";
            switch (num)
            {
                case "1":
                    OutputData(nameFile);
                    break;
                case "2":
                    InputData(nameFile);
                    break;
                default: Console.WriteLine("Не верный ввод");
                    break;
            }
        }
/// <summary>
/// Чтение данных из файла и вывод в консоль
/// </summary>
/// <param name="nameFile">Имя файла</param>
        static void OutputData(string nameFile)
        {
            using (StreamReader sr = new StreamReader(nameFile))
            {
                string worker;
                Console.WriteLine($"{"ID",3}{"Дата  время",17}{"Ф.И.О.",30}{"Возраст",8}{"Рост",5}{"Дата рождения",14}{"Место рождения рождения",30}");
                while ((worker = sr.ReadLine()) != null)
                {
                    string[] data = worker.Split('#');
                    Console.WriteLine($"{data[0],3}{data[1],17}{data[2],30}{data[3],8}{data[4],5}{data[5],14}{data[6],30}");
                }
            }
            Console.ReadKey();
        }
/// <summary>
/// Заполнение файла данными о сотрудниках
/// </summary>
/// <param name="nameFile">Имя файла</param>
        static void InputData(string nameFile)
        {
            char key = 'д';
            int id;
            if (File.Exists(nameFile))//Проверка существует файл или нет
            {
                string[] buf = File.ReadAllLines(nameFile);
                id = buf.Length;
            }
            else
            {
                id = 0;
            }
            using (StreamWriter sw = new StreamWriter(nameFile, true)) //Если файл не существует, то создается и заполняется данными, если существует - добавляются данные
            {
                do
                {
                    sw.WriteLine(ReadLineData(id));
                    Console.Write("\nДобавить сотрудников н/д"); key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == 'д');
            }
        }
/// <summary>
/// Чтение данных вводимых пользователем
/// </summary>
/// <param name="id">Порядковый номер</param>
/// <returns></returns>
        static string ReadLineData(int id)
        {
            string worker = string.Empty;
            worker += $"{++id}#";
            string now = DateTime.Now.ToString("g");
            worker += $"{now}#";
            Console.WriteLine("\nВведите Ф.И.О. сотрудника:");
            worker += $"{Console.ReadLine()}#";
            Console.WriteLine("Введите возраст сотрудника:");
            worker += $"{int.Parse(Console.ReadLine())}#";
            Console.WriteLine("Введите рост сотрудника:");  
            worker += $"{int.Parse(Console.ReadLine())}#";
            Console.WriteLine("Введите дату рождения сотрудника:");
            DateTime DateOfBirth = DateTime.Parse(Console.ReadLine());
            worker += $"{DateOfBirth:d}#";
            Console.WriteLine("Введите место рождения сотрудника:");
            worker += $"{Console.ReadLine()}";
            return worker;
        }
    }
}
