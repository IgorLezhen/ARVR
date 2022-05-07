using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

/*
Задание 4. Записная книжка
Что нужно сделать:
Программа спрашивает у пользователя данные о контакте:
    ФИО
    Улица
    Номер дома
    Номер квартиры
    Мобильный телефон
    Домашний телефон

*/
namespace Exercise4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Path = "Address.xml";
            string fio, street, mobilePhone, flatPhone;
            int houseNum, flatNum;

            Console.WriteLine("Введите ФИО контакта:");
            fio = Console.ReadLine();
            if (fio.Length != 0)
            {
                Console.WriteLine("Введите улицу:");
                street = Console.ReadLine();
                Console.WriteLine("Введите номер дома:");
                houseNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите номер квартиры:");
                flatNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите мобильный телефон:");
                mobilePhone = Console.ReadLine();
                Console.WriteLine("Введите домашний телефон:");
                flatPhone = Console.ReadLine();
                XElement person = new XElement("Person",
                 new XAttribute("name", fio),
                 new XElement("Address",
                     new XElement("Street", street),
                     new XElement("Street", houseNum),
                     new XElement("FlatNumber", flatNum)),
                 new XElement("Phones",
                    new XElement("MobilePhone", mobilePhone),
                    new XElement("FlatPhone", flatPhone)));

                person.Save(Path);
            }
            Console.ReadKey();
        }
    }
}
