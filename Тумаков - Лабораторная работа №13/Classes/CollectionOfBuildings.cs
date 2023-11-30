namespace Тумаков___Лабораторная_работа__13
{
    /// <summary>
    /// Класс, описывающий коллекцию из 10 зданий.
    /// </summary>
    class CollectionOfBuildings
    {
        #region Поля
        private Building[] buildingsArray = new Building[10];
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство, позволяющее читать поле buildingsArray.
        /// </summary>
        public Building[] BuildingsArray
        {
            get
            {
                return buildingsArray;
            }
        }
        #endregion

        #region Индексаторы
        /// <summary>
        /// Индексатор, позволяющий получить объект Building по его номеру.
        /// </summary>
        /// <param name="index"> Номер здания. </param>
        /// <returns> Объект Building. </returns>
        public Building this[int index]
        {
            get
            {
                return buildingsArray[index];
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод, позволяющий добавлять здание в массив зданий.
        /// </summary>
        /// <param name="building"> Объект Building. </param>
        public void AddingBuildingToArray(Building building)
        {
            buildingsArray[building.BuildingNumber] = building;
        }
        #endregion
    }
}
