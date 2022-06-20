using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankA
{
    class Individual<T> : Client<T>
    {
        public new string NumAccount { get ;  set ; }
        public Individual (
            int Id, 
            string Type,
            string Surname, 
            string Name, 
            string Patronymic,
            string NumAccount,
            T SumAccount, 
            string StatusAccount)
            : base (
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
