using System;

namespace Тумаков___Лабораторная_работа__14
{
    /// <summary>
    /// Класс, описывающий атрибут, содержащий данные о разработчике и о дате разработки.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    class DeveloperInfoEx1Attribute : Attribute
    {
        #region Автосвойства
        public string DeveloperName { get; }
        public string ClassDevelopmentDate { get; }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, создающий экземпляр класса DeveloperInfoEx1Attribute.
        /// </summary>
        /// <param name="developerName"> Имя разработчика. </param>
        /// <param name="classDevelopmentDate"> Дата разработки. </param>
        public DeveloperInfoEx1Attribute(string developerName, string classDevelopmentDate)
        {
            DeveloperName = developerName;
            ClassDevelopmentDate = classDevelopmentDate;
        }
        #endregion
    }
}
