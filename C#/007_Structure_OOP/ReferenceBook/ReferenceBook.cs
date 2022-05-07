using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReferenceBook
{
    public struct ReferenceBook
    {
        private Worker[] workers; // Основной массив для хранения данных
        private string nameFile; // путь к файлу с данными
        int index; // текущий элемент для добавления в workers       

        /// <summary>
        /// Констрктор
        /// </summary>
        /// <param name="nameFile">Путь в файлу с данными</param>
        public ReferenceBook(string nameFile)
        {
            this.nameFile = nameFile; // Сохранение пути к файлу с данными
            index = 0; // текущая позиция для добавления сотрудника в workers
            workers = new Worker[1]; // инициализаия массива сотрудников.    | изначально предпологаем, что данных нет
            //Load(); // Загрузка данных
        }

        /// <summary>
        /// Метод загрузки данных
        /// </summary>
        internal int Load(string nameFile)
        {
            int id = 0;
            using (StreamReader sr = new StreamReader(nameFile))
            {
                
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    Add(new Worker(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), Convert.ToDateTime(args[5]), args[6]));
                    id = Convert.ToInt32(args[0]);
                }
            }
            return id;
        }

        /// <summary>
        /// Метод добавления сотрудника в хранилище
        /// </summary>
        /// <param name="ConcreteWorker">Сотрудник</param>
        internal void Add(Worker ConcreteWorker)
        {
            Resize(index >= workers.Length);
            workers[index] = ConcreteWorker;
            index++;
        }

        /// <summary>
        /// Метод увеличения текущего хранилища
        /// </summary>
        /// <param name="Flag">Условие увеличения</param> 
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref workers, workers.Length+10);
            }
        }

        /// <summary>
        /// Вывод данных сотрудника в консоль
        /// </summary>
        public void PrintWorkerToConsole(int num)
        {
            if (num - 1 > workers.Length || workers[0].Id == 0)
            {
                Console.WriteLine("Записи не существует!");

            }
            else
            {
                Console.WriteLine($"{"ID",3}{"Дата  время",17}{"Ф.И.О.",30}{"Возраст",8}{"Рост",5}{"Дата рождения",14}{"Место рождения рождения",30}");
                for (int i = 0; i < index; i++)
                {
                    if (i == num - 1)
                    {
                        Console.WriteLine(workers[i].Print());
                    }
                }
            }
        }

        /// <summary>
        /// Метод сохранения данных
        /// </summary>
        /// <param name="nameFile">Путь к файлу сохранения</param>
        public void Save(string nameFile)
        {
            //File.Delete(nameFile);
            string temp = string.Empty ;
            for (int i = 0; i < this.index; i++)
            {
                if (workers[i].Id != 0)
                {
                    temp += string.Format("{0}#", this.workers[i].Id);
                    temp += string.Format("{0}#", this.workers[i].Now);
                    temp += string.Format("{0}#", this.workers[i].Fio);
                    temp += string.Format("{0}#", this.workers[i].Age);
                    temp += string.Format("{0}#", this.workers[i].Height);
                    temp += string.Format("{0}#", this.workers[i].DateOfBirth);
                    temp += string.Format("{0}\n", this.workers[i].PlaceOfBirth);
                }
            }
            File.WriteAllText(nameFile,temp);
        }

        /// <summary>
        /// Метод удаления данных сотрудника
        /// </summary>
        /// <param name="num">ID номер сотрудника</param>
        public void DeleteWorker(int num)
        {
            for (int i = 0; i < index; i++)
            {
                if (workers[i].Id == num) workers[i].Id = 0;
            }       
        }

        /// <summary>
        /// Метод редактирования данных сотрудника
        /// </summary>
        /// <param name="num">ID номер сотрудника</param>
        /// <param name="temp">Массив данных о сотруднике</param>
        public void ReplaceWorker(int num, string [] temp)
        {
            for (int i = 0; i < index; i++)
            {
                if (workers[i].Id == num)
                {
                    workers[i].Now = DateTime.Parse(temp[0]);
                    workers[i].Fio = temp[1];
                    workers[i].Age = Convert.ToInt32(temp[2]);
                    workers[i].Height = Convert.ToInt32(temp[3]);
                    workers[i].DateOfBirth = DateTime.Parse(temp[4]);
                    workers[i].PlaceOfBirth = temp[5];
                }
            }
        }

        /// <summary>
        /// Вывод сотруднудников в определенном диапазоне дат
        /// </summary>
        /// <param name="dateHome">Начальная дата</param>
        /// <param name="dateEnd">Конечная дата</param>
        public void DateHomeEnd(DateTime dateHome, DateTime dateEnd)
        {
            Console.WriteLine($"{"ID",3}{"Дата  время",17}{"Ф.И.О.",30}{"Возраст",8}{"Рост",5}{"Дата рождения",14}{"Место рождения рождения",30}");
            for (int i = 0; i < index; i++)
            {
                //преобразование в формат только дата
                string dh = dateHome.ToString("d");
                string de = dateEnd.ToString("d");
                string dn = Convert.ToDateTime(workers[i].Now).ToString("d");
                if (Convert.ToDateTime(dh) <= Convert.ToDateTime(dn) && Convert.ToDateTime(dn) <= Convert.ToDateTime(de)) 
                {
                    Console.WriteLine(workers[i].Print());
                }
            }
        }

        /// <summary>
        /// Сортировка по возрастанию и убыванию по дате добавления
        /// </summary>
        /// <param name="sort">Параметр  сортировки по возрастанию или убыванию</param>
        public void Sort(string sort)
        {
            DateTime[] arrNow = new DateTime[index];
            for (int i = 0; i < index; i++)
            {
                    arrNow[i] = Convert.ToDateTime(workers[i].Now);
            }
            Array.Sort(arrNow, workers);
            if (sort == "desc") Array.Reverse(workers);
            Console.WriteLine($"{"ID",3}{"Дата  время",17}{"Ф.И.О.",30}{"Возраст",8}{"Рост",5}{"Дата рождения",14}{"Место рождения рождения",30}");
            for (int i = 0; i < index; i++)
            {
                    Console.WriteLine(workers[i].Print());
            }
        }
    }
}
