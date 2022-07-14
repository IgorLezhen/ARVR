namespace BankA_Exercise3
{
    /// <summary>
    /// Класс Client, формирует базу клиентов
    /// </summary>
    /// <typeparam name="T">Тип переменной</typeparam>
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
        public string TypeAccount { get; set; }
        public string StatusAccount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id клиента</param>
        /// <param name="type">Тип клиента</param>
        /// <param name="surname">Фамилия клиента</param>
        /// <param name="name">Имя клиента</param>
        /// <param name="patronymic">Отчество клиента</param>
        /// <param name="sumAccount">Баланс счёта</param>
        /// <param name="statusAccount">Статус счёта</param>
        public Client(
            int id,
            string type,
            string surname,
            string name,
            string patronymic,
            T sumAccount,
            string typeAccount,
            string statusAccount
            )
        {
            Id = id;
            Type = type;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            SumAccount = sumAccount;
            TypeAccount = typeAccount;
            StatusAccount = statusAccount;
        }
        /// <summary>
        /// Задание номера счёта
        /// </summary>
        /// <returns></returns>
        public string ClientNumAccount()
        {
            return Id.ToString().PadLeft(8, '0');
        }
    }
}

