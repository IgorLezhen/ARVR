using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateVariableAndOutput
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
            string output;//Вывод 

            //Вариант 1
            Console.WriteLine("Вариант 1");
            Console.WriteLine();
            Console.WriteLine("ФИО: " + fullName);
            Console.WriteLine("Возраст: " + age);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Баллы по программированию: " + markProgramming);
            Console.WriteLine("Балы по математике: " + markMathematics);
            Console.WriteLine("Балы по физике: " + markPhysics);
            Console.WriteLine();
            Console.ReadKey();

            //Вариант 2
            Console.WriteLine("Вариант 2");
            Console.WriteLine();
            Console.WriteLine($"ФИО: {fullName}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Баллы по программированию: {markProgramming}");
            Console.WriteLine($"Балы по математике: {markMathematics}");
            Console.WriteLine($"Балы по физике: {markPhysics}");
            Console.WriteLine();
            Console.ReadKey();

            //Вариант 3
            Console.WriteLine("Вариант 3");
            Console.WriteLine();
            Console.WriteLine($"{"ФИО:",30} {fullName,30}");
            Console.WriteLine($"{"Возраст:",30} {age,30}");
            Console.WriteLine($"{"Email:",30} {email,30}");
            Console.WriteLine($"{"Баллы по программированию:",30} {markProgramming,30}");
            Console.WriteLine($"{"Балы по математике:",30} {markMathematics,30}");
            Console.WriteLine($"{"Балы по физике:",30} {markPhysics,30}");
            Console.WriteLine();
            Console.ReadKey();

            //Вариант 4
            output = "ФИО: \t{0} \nВозраст: \t{1} \nEmail: \t{2} \nБаллы по программированию: \t{3} \nБалы по математике: \t{4} \nБалы по физике: \t{5}";
          
            Console.WriteLine("Вариант 4");
            Console.WriteLine();
            Console.WriteLine(output,
                              fullName,
                              age,
                              email,
                              markProgramming,
                              markMathematics,
                              markPhysics);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
