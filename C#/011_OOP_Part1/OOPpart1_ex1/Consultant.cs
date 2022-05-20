using System;

namespace OOPpart1_ex1
{
    /*
    Класс Консультант используется для заполнения листа consultant с методом замены номера телефона на символ *
    P.S. Как сделать одним классом не хватает опыта пока ещё)
    */
    class Consultant 
    {
        #region Поля
        private string surname;
        private string name;
        private string patronymic;
        private string idPassport;
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство фамилия
        /// </summary>
        public string Surname { get { return this.surname; } }
        /// <summary>
        /// Свойство имя
        /// </summary>
        public string Name { get { return this.name; } }
        /// <summary>
        /// Свойство отчество
        /// </summary>
        public string Patronymic { get { return this.patronymic; } }
        /// <summary>
        /// Свойство номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Свойство серия и номер паспорта
        /// </summary>
        public string IdPassport { get { return ClientPassport(); } }
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
        public Consultant(string Surname, string Name, string Patronymic, string PhoneNumber, string IdPassport)
        {
            this.surname = Surname;
            this.name = Name;
            this.patronymic = Patronymic;
            this.PhoneNumber = PhoneNumber;
            this.idPassport = IdPassport;
        }
        #endregion

        #region Метод
        /// <summary>
        /// Замена номера телефона символами * для консультанта
        /// </summary>
        /// <returns></returns>
        public string ClientPassport()
        {
            string txt = String.Empty;
            if (this.idPassport != String.Empty)
            {
                txt = "********";
            }
            return txt;
        }
        #endregion
    }
}
