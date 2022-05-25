using System;

namespace OOPpart1_ex2
{
    /*
    Класс Консультант используется для заполнения листа consultant с методом замены номера телефона на символ *
    P.S. Как сделать одним классом не хватает опыта пока ещё)
    */
    class Consultant: Manager
    {
        #region Поля
        private string idPassport;
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство фамилия
        /// </summary>
         public new string IdPassport { get { return ClientPassport(); } set { idPassport = value; } }
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
            :base (Surname, Name, Patronymic, PhoneNumber, IdPassport)
        {
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
