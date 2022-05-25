namespace OOPpart1_ex2
{
    /*
    Класс Клиент используется для заполнения листа client данными, загруженными из файла _base.json, с последующим формированием листа consultant с методом замены номера телефона на символ *
    P.S. Как сделать одним классом не хватает опыта пока ещё)
    */
    public class Client
    {
        #region Свойства
        /// <summary>
        /// Свойство фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Свойство имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Свойство отчество
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Свойство номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Свойство серия и номер паспорта
        /// </summary>
        public string IdPassport { get; set; }
        #endregion

        #region Конструктор
        /// <summary>
        /// Конструктор клиента
        /// </summary>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Name">Имя</param>
        /// <param name="Patronymic">Отчество</param>
        /// <param name="PhoneNumber">Номер телефона</param>
        /// <param name="IdPassport">Серия и номер паспорта</param>
        public Client(string Surname, string Name, string Patronymic, string PhoneNumber, string IdPassport)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.Patronymic = Patronymic;
            this.PhoneNumber = PhoneNumber;
            this.IdPassport = IdPassport;
        }
        #endregion
    }
}
