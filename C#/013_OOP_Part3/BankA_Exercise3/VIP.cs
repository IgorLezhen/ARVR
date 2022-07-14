namespace BankA_Exercise3
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
            string TypeAccount,
            string StatusAccount)
            : base(
                  Id,
                  Type,
                  Surname,
                  Name,
                  Patronymic,
                  SumAccount,
                  TypeAccount,
                  StatusAccount)
        {
            this.NumAccount = NumAccount;
        }
    }
}
