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
            string nameFile = "worker.txt";
            int id;
            string[] temp;
            if (File.Exists(nameFile) == false)//Проверка существует файл или нет
            {
                File.AppendAllText(nameFile, "");
            }

            ReferenceBook book = new ReferenceBook(nameFile);
            id = book.Load(nameFile); //идентификатор id записи

            Console.WriteLine("Справочник «Сотрудники»");
            Console.WriteLine("Просмотр записи 1");
            Console.WriteLine("Создание записи 2");
            Console.WriteLine("Удалить запись 3");
            Console.WriteLine("Редактировать запись 4");
            Console.WriteLine("Загрузка записей в выбранном диапазоне дат 5");
            Console.WriteLine("Сортировка по возрастанию и убыванию даты 6");
            Console.WriteLine("Ваш выбор:");

            switch (Console.ReadLine())
            {
                case "1": //Вывод в консоль данных о содруднике по определенному номеру ID
                    Console.WriteLine("Введите id сотрудника:");
                    book.PrintWorkerToConsole(Convert.ToInt32(Console.ReadLine()));
                    break;
                case "2": //Добавление новых сотрудников
                    char key = 'д';
                    do
                    {
                        temp = InputData();
                        book.Add(new Worker(++id, DateTime.Parse(temp[0]), temp[1], Convert.ToInt32(temp[2]), Convert.ToInt32(temp[3]), DateTime.Parse(temp[4]), temp[5]));
                        book.Save(nameFile);
                        Console.Write("\nДобавить сотрудников н/д"); key = Console.ReadKey(true).KeyChar;
                    } while (char.ToLower(key) == 'д');
                    break;
                case "3": //Удаление данных о сотруднике
                    Console.WriteLine("Введите id сотрудника для удаления:");
                    book.DeleteWorker(Convert.ToInt32(Console.ReadLine()));
                    book.Save(nameFile);
                    break;
                case "4": //Редактирование данных сотрудника
                    Console.WriteLine("Введите id сотрудника для редактирования:");
                    id = Convert.ToInt32(Console.ReadLine());
                    temp = InputData();
                    book.ReplaceWorker(id, temp);
                    book.Save(nameFile);
                    break;
                case "5":
                    Console.WriteLine("Введите начальную дату:");
                    DateTime dateHome = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Введите конечную дату:");
                    DateTime dateEnd = DateTime.Parse(Console.ReadLine());
                    book.DateHomeEnd(dateHome, dateEnd);
                    break;
                case "6":
                    Console.WriteLine("Введите способ сортировки\nпо возрастанию - 1 \nпо убыванию - 2");
                    switch (Console.ReadLine())
                    {
                        case "1": //по возрастанию
                            book.Sort("asc");
                            break;
                        case "2": //по убыванию
                            book.Sort("desc");
                            break;
                        default:
                            Console.WriteLine("Не верный ввод");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Не верный ввод");
                    break;
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Ввод данных о сотруднике
        /// </summary>
        /// <returns></returns>
        private static string[] InputData()
        {
            string[] worker = new string[6];
            worker[0] = DateTime.Now.ToString("g");
            Console.WriteLine("\nВведите Ф.И.О. сотрудника:");
            worker[1]  = Console.ReadLine();
            Console.WriteLine("Введите возраст сотрудника:");
            int age = int.Parse(Console.ReadLine());
            worker[2] = $"{age}";
            Console.WriteLine("Введите рост сотрудника:");
            int height = int.Parse(Console.ReadLine());
            worker[3] = $"{height}";
            Console.WriteLine("Введите дату рождения сотрудника:");
            DateTime DateOfBirth = DateTime.Parse(Console.ReadLine());
            worker[4] = $"{DateOfBirth}";
            Console.WriteLine("Введите место рождения сотрудника:");
            worker[5] = Console.ReadLine();
            return worker;
        }







    }
}