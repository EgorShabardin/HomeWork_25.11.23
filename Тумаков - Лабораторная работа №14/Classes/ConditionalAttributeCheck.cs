#define DEBUG_ACCOUNT

namespace Тумаков___Лабораторная_работа__14
{
    /// <summary>
    /// Класс для проверки работы условного атрибута.
    /// </summary>
    class ConditionalAttributeCheck
    {
        /// <summary>
        /// Метод, вызывающий метод DumpToScrenn объекта bankAccount.
        /// </summary>
        /// <param name="bankAccount"> Банковский счет. </param>
        public static void CallingMethodDumpToScreen(BankAccount bankAccount)
        {
            bankAccount.DumpToScreen();
        }
    }
}
