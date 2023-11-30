namespace Тумаков___Лабораторная_работа__14
{
    [DeveloperInfoEx1("Егор", "18.11.2023")]
    /// <summary>
    /// Класс, описывающий рациональное число.
    /// </summary>
    class RationalNumber
    {
        #region Поля
        readonly int numerator;
        readonly int denominator;
        #endregion

        #region Методы
        /// <summary>
        /// Метод, создающий экземпляр класса RationalNumber.
        /// </summary>
        /// <param name="numerator"> Числитель. </param>
        /// <param name="denominator"> Знаменатель. </param>
        /// <returns> Возвращает созданный объект или null. </returns>
        public static RationalNumber MakeRationalNumber(int numerator, int denominator)
        {
            if (denominator > 0)
            {
                return new RationalNumber(numerator, denominator);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Переопределение метода ToString.
        /// </summary>
        /// <returns> Возвращает строку, содержащую рациональное число. </returns>
        public override string ToString()
        {
            if (denominator == 1)
            {
                return $"{numerator}";
            }
            else
            {
                return $"{numerator}/{denominator}";
            }
        }

        /// <summary>
        /// Переопределение методы Equals.
        /// </summary>
        /// <param name="obj"> Рациональное число. </param>
        /// <returns> Возвращает true, если числа равны, иначе false. </returns>
        public override bool Equals(object obj)
        {
            if (obj is RationalNumber rationalNumber)
            {
                int newDenominator = FindingDenominator(denominator, rationalNumber.denominator);
                int newFirstNumerator = numerator * (newDenominator / denominator);
                int newSecondNumerator = rationalNumber.numerator * (newDenominator / rationalNumber.denominator);

                if (newFirstNumerator == newSecondNumerator)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Переопределение методы GetHashCode.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Метод, позволяющий найти общий знаменатель двух рациональных чисел.
        /// </summary>
        /// <param name="firstDenominator"> Первое рациональное число. </param>
        /// <param name="secondDenominator">Второе рациональное число. </param>
        /// <returns> Возвращает общий знаменатель двух рациональных чисел. </returns>
        private static int FindingDenominator(int firstDenominator, int secondDenominator)
        {
            int firstNumber = firstDenominator;
            int secondNumber = secondDenominator;

            while ((firstNumber != 0) && (secondNumber != 0))
            {
                if (firstNumber > secondNumber)
                {
                    firstNumber %= secondNumber;
                }
                else
                {
                    secondNumber %= firstNumber;
                }
            }

            return (firstDenominator * secondDenominator) / (firstNumber + secondNumber);
        }
        #endregion

        #region Переопределение операторов
        /// <summary>
        /// Переопределение оператора +.
        /// </summary>
        /// <param name="firstRationalNumber"> Первый операнд, рациональное число. </param>
        /// <param name="secondRationalNumber">Второй операнд, рациональное число. </param>
        /// <returns> Возвращает сумму двух операндов. </returns>
        public static RationalNumber operator +(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newNumerator = (firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator)) + (secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator));

            return new RationalNumber(newNumerator, newDenominator);
        }

        /// <summary>
        /// Переопределение оператора -.
        /// </summary>
        /// <param name="firstRationalNumber"> Первый операнд, рациональное число. </param>
        /// <param name="secondRationalNumber">Второй операнд, рациональное число. </param>
        /// <returns> Возвращает разность двух операндов. </returns>
        public static RationalNumber operator -(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newNumerator = (firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator)) - (secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator));

            return new RationalNumber(newNumerator, newDenominator);
        }

        /// <summary>
        /// Переопределение оператора *.
        /// </summary>
        /// <param name="firstRationalNumber"> Первый операнд, рациональное число. </param>
        /// <param name="secondRationalNumber">Второй операнд, рациональное число. </param>
        /// <returns> Возвращает произведение двух операндов. </returns>
        public static RationalNumber operator *(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            return new RationalNumber(firstRationalNumber.numerator * secondRationalNumber.numerator, firstRationalNumber.denominator * secondRationalNumber.denominator);
        }

        /// <summary>
        /// Переопределение оператора /.
        /// </summary>
        /// <param name="firstRationalNumber"> Первый операнд, рациональное число. </param>
        /// <param name="secondRationalNumber">Второй операнд, рациональное число. </param>
        /// <returns> Возвращает частное двух операндов. </returns>
        public static RationalNumber operator /(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            return new RationalNumber(firstRationalNumber.numerator * secondRationalNumber.denominator, firstRationalNumber.denominator * secondRationalNumber.numerator);
        }

        /// <summary>
        /// Переопределение оператора %.
        /// </summary>
        /// <param name="firstRationalNumber"> Первый операнд, рациональное число. </param>
        /// <param name="secondRationalNumber">Второй операнд, рациональное число. </param>
        /// <returns> Возвращает остаток от деления двух операндов. </returns>
        public static int operator %(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            RationalNumber rationalNumber = firstRationalNumber / secondRationalNumber;

            return (rationalNumber.numerator % rationalNumber.denominator);
        }

        /// <summary>
        /// Переопределение оператора ==.
        /// </summary>
        /// <param name="firstRationalNumber"> Первый операнд, рациональное число. </param>
        /// <param name="secondRationalNumber">Второй операнд, рациональное число. </param>
        /// <returns> Возвращает true, если операнды равны, иначе false. </returns>
        public static bool operator ==(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newFirstNumerator = firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator);
            int newSecondNumerator = secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator);

            return newFirstNumerator == newSecondNumerator;
        }

        /// <summary>
        /// Переопределение оператора !=.
        /// </summary>
        /// <param name="firstRationalNumber"> Первый операнд, рациональное число. </param>
        /// <param name="secondRationalNumber">Второй операнд, рациональное число. </param>
        /// <returns> Возвращает true, если операнды неравны, иначе false. </returns>
        public static bool operator !=(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newFirstNumerator = firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator);
            int newSecondNumerator = secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator);

            return newFirstNumerator != newSecondNumerator;
        }

        /// <summary>
        /// Переопределение оператора >.
        /// </summary>
        /// <param name="firstRationalNumber"> Первый операнд, рациональное число. </param>
        /// <param name="secondRationalNumber">Второй операнд, рациональное число. </param>
        /// <returns> Возвращает true, если первый операнд больше второго, иначе false. </returns>
        public static bool operator >(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newFirstNumerator = firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator);
            int newSecondNumerator = secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator);

            return newFirstNumerator > newSecondNumerator;
        }

        /// <summary>
        /// Переопределение оператора <.
        /// </summary>
        /// <param name="firstRationalNumber"> Первый операнд, рациональное число. </param>
        /// <param name="secondRationalNumber">Второй операнд, рациональное число. </param>
        /// <returns> Возвращает true, если первый операнд меньше второго, иначе false. </returns>
        public static bool operator <(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newFirstNumerator = firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator);
            int newSecondNumerator = secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator);

            return newFirstNumerator < newSecondNumerator;
        }

        /// <summary>
        /// Переопределение оператора >=.
        /// </summary>
        /// <param name="firstRationalNumber"> Первый операнд, рациональное число. </param>
        /// <param name="secondRationalNumber">Второй операнд, рациональное число. </param>
        /// <returns> Возвращает true, если первый операнд больше или равен второму, иначе false. </returns>
        public static bool operator >=(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newFirstNumerator = firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator);
            int newSecondNumerator = secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator);

            return newFirstNumerator >= newSecondNumerator;
        }

        /// <summary>
        /// Переопределение оператора <=.
        /// </summary>
        /// <param name="firstRationalNumber"> Первый операнд, рациональное число. </param>
        /// <param name="secondRationalNumber">Второй операнд, рациональное число. </param>
        /// <returns> Возвращает true, если первый операнд меньше или равен второму, иначе false. </returns>
        public static bool operator <=(RationalNumber firstRationalNumber, RationalNumber secondRationalNumber)
        {
            int newDenominator = FindingDenominator(firstRationalNumber.denominator, secondRationalNumber.denominator);
            int newFirstNumerator = firstRationalNumber.numerator * (newDenominator / firstRationalNumber.denominator);
            int newSecondNumerator = secondRationalNumber.numerator * (newDenominator / secondRationalNumber.denominator);

            return newFirstNumerator <= newSecondNumerator;
        }

        /// <summary>
        /// Переопределение оператора ++.
        /// </summary>
        /// <param name="rationalNumber"> Операнд, рациональное число. </param>
        /// <returns> Возвращает рациональное число, которое на единицу больше предыдущего. </returns>
        public static RationalNumber operator ++(RationalNumber rationalNumber)
        {
            return new RationalNumber(rationalNumber.numerator + rationalNumber.denominator, rationalNumber.denominator);
        }

        /// <summary>
        /// Переопределение оператора --.
        /// </summary>
        /// <param name="rationalNumber"> Операнд, рациональное число. </param>
        /// <returns> Возвращает рациональное число, которое на единицу меньше предыдущего. </returns>
        public static RationalNumber operator --(RationalNumber rationalNumber)
        {
            return new RationalNumber(rationalNumber.numerator - rationalNumber.denominator, rationalNumber.denominator);
        }

        /// <summary>
        /// Переопределение приведения рационального числа в число типа float.
        /// </summary>
        /// <param name="rationalNumber"> Рациональное число. </param>
        public static explicit operator float(RationalNumber rationalNumber)
        {
            return (float)rationalNumber.numerator / rationalNumber.denominator;
        }

        /// <summary>
        /// Переопределение приведения рационального числа в число типа int.
        /// </summary>
        /// <param name="rationalNumber"> Рациональное число. </param>
        public static explicit operator int(RationalNumber rationalNumber)
        {
            return rationalNumber.numerator / rationalNumber.denominator;
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, создающий экземпляр класса RationalNumber.
        /// </summary>
        /// <param name="numerator"> Числитель. </param>
        /// <param name="denominator"> Знаменатель. </param>
        private RationalNumber(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
        #endregion
    }
}