using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankA
{
    class Client<T>
    {
        private string numAccount;

        public int Id { get; set; }
        public string Type { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string NumAccount { get { return ClientNumAccount(); } set { numAccount = value; } }
        public T SumAccount { get; set; }
        public string StatusAccount { get; set; }

        public Client (
            int id,
            string type,
            string surname,
            string name,
            string patronymic,
            
            T sumAccount,
            string statusAccount
            )
        {
            Id = id;
            Type = type;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            
            SumAccount = sumAccount;
            StatusAccount = statusAccount;
        }

        public string ClientNumAccount()
        {
            return Id.ToString().PadLeft(8, '0');
        }
    }
}
