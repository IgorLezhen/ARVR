using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceBook
{
    struct Worker
    {
        #region Свойства
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Id { get { return this.id; } set { this.id = value; } }

        /// <summary>
        /// Дата и время создания
        /// </summary>
        public DateTime Now { get { return this.now; } set { this.now = value; } }

        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string Fio { get { return this.fio; } set { this.fio = value; } }

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age { get { return this.age; } set { this.age = value; } }

        /// <summary>
        /// Рост сотрудника
        /// </summary>
        public int Height { get { return this.height; } set { this.height = value; } }

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        public DateTime DateOfBirth { get { return this.dateOfBirth; } set { this.dateOfBirth = value; } }

        /// <summary>
        /// Место рождения сотрудника
        /// </summary>
        public string PlaceOfBirth { get { return this.placeOfBirth; } set { this.placeOfBirth = value; } }

        #endregion

        #region Конструкторы
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="id">Порядковый номер</param>
        /// <param name="now">Дата и время создания</param>
        /// <param name="fio">ФИО сотрудника</param>
        /// <param name="age">Возраст сотрудника</param>
        /// <param name="height">Рост сотрудника</param>
        /// <param name="dateOfBirth">Дата рождения сотрудника</param>
        /// <param name="placeOfBirth">Место рождения сотрудника</param>
        public Worker(int Id, DateTime Now, string Fio, int Age, int Height, DateTime DateOfBirth, string PlaceOfBirth)
        {
            this.id = Id;
            this.now = Now;
            this.fio = Fio;
            this.age = Age;
            this.height = Height;
            this.dateOfBirth = DateOfBirth;
            this.placeOfBirth = PlaceOfBirth;
        }
        #endregion

        #region Методы
        public string Print()
        {
            return $"{this.id,3}{this.now,17:g}{this.fio,30}{this.age,8}{this.height,5}{this.dateOfBirth,14:d}{this.placeOfBirth,30}";
        }
        #endregion

        #region Поля

        /// <summary>
        /// Поле "Порядковый номер"
        /// </summary>
        private int id;

        /// <summary>
        /// Поле "Дата и время создания"
        /// </summary>
        private DateTime now;

        /// <summary>
        /// Поле "ФИО сотрудника"
        /// </summary>
        private string fio;

        /// <summary>
        /// Поле "Возраст сотрудника"
        /// </summary>
        private int age;

        /// <summary>
        /// Поле "Рост сотрудника"
        /// </summary>
        private int height;

        /// <summary>
        /// Поле "Дата рождения сотрудника"
        /// </summary>
        private DateTime dateOfBirth;

        /// <summary>
        /// Поле "Место рождения сотрудника"
        /// </summary>
        private string placeOfBirth;
        #endregion
    }
}
