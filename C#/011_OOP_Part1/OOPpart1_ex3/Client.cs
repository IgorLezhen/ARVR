namespace OOPpart1_ex3
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
        /// <summary>
        /// Дата и время изменения записи
        /// </summary>
        public string DateTimeReplace { get; set; }
        /// <summary>
        /// Какие данные изменены
        /// </summary>
        public string DataReplace { get; set; }
        /// <summary>
        /// Тип изменений
        /// </summary>
        public string TypeReplace { get; set; }
        /// <summary>
        /// Кто изменил данные (консультант или менеджер)
        /// </summary>
        public string AutorReplace { get; set; }
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
        ///  <param name="DateTimeReplace">Дата и время изменения записи</param>
        ///  <param name="DataReplace">Какие данные изменены</param>
        ///  <param name="TypeReplace">Тип изменений</param>
        ///  <param name="AutorReplace">Кто изменил данные (консультант или менеджер)</param>
        public Client(string Surname, string Name, string Patronymic, string PhoneNumber, string IdPassport,
                      string DateTimeReplace, string DataReplace, string TypeReplace, string AutorReplace)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.Patronymic = Patronymic;
            this.PhoneNumber = PhoneNumber;
            this.IdPassport = IdPassport;
            this.DateTimeReplace = DateTimeReplace;
            this.DataReplace = DataReplace;
            this.TypeReplace = TypeReplace;
            this.AutorReplace = AutorReplace;
        }
        #endregion
    }
}
