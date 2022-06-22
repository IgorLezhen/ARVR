using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankA
{
    /// <summary>
    /// Класс VIP клиентов, наследуется от класса Client
    /// </summary>
    /// <typeparam name="T">Тип переменной</typeparam>
    internal class VIP<T> : Client<T>
    {
        public new string NumAccount { get; set; }
        public VIP(
            int Id,
            string Type,
            string Surname,
            string Name,
            string Patronymic,
            string NumAccount,
            T SumAccount,
            string StatusAccount)
            : base(
                  Id,
                  Type,
                  Surname,
                  Name,
                  Patronymic,
                  
                  SumAccount,
                  StatusAccount)
        {
            this.NumAccount = NumAccount;
        }
    }
}
