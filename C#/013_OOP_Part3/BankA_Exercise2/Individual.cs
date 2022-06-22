namespace BankA_Exercise2
{
    /// <summary>
    /// Класс Individual клиентов (физические лица), наследуется от класса Client
    /// </summary>
    /// <typeparam name="T">Тип переменной</typeparam>
    class Individual<T> : Client<T>
    {
        public new string NumAccount { get; set; }
        public Individual(
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
