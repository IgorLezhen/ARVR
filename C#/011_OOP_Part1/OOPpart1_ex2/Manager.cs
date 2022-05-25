namespace OOPpart1_ex2
{
    internal class Manager
    {
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
 
        public Manager(string Surname, string Name, string Patronymic, string PhoneNumber, string IdPassport)
            
        {
            this.Surname = Surname;
            this.Name = Name;
            this.Patronymic = Patronymic;
            this.PhoneNumber = PhoneNumber;
            this.IdPassport = IdPassport;
        }
    }
}
