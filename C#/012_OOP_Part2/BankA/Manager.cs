namespace BankA
{
    internal class Manager
    {
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

        public Manager(string Surname, string Name, string Patronymic, string PhoneNumber, string IdPassport,
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
    }
}
