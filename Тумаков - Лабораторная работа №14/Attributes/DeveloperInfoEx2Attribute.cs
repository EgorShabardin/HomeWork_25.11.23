﻿using System;

namespace Тумаков___Лабораторная_работа__14
{
    /// <summary>
    /// Класс, описывающий атрибут, содержащий данные о разработчике и организации.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    class DeveloperInfoEx2Attribute : Attribute
    {
        #region Поля
        readonly string developerName;
        readonly string organizationName;
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, создающий экземпляр класса DeveloperInfoEx2Attribute.
        /// </summary>
        /// <param name="developerName"> Имя разработчика. </param>
        /// <param name="organizationName"> Название организации. </param>
        public DeveloperInfoEx2Attribute(string developerName, string organizationName)
        {
            this.developerName = developerName;
            this.organizationName = organizationName;
        }
        #endregion
    }
}
