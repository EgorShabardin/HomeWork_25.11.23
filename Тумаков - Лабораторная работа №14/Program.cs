using System;

namespace Тумаков___Лабораторная_работа__14
{
    class Program
    {
        static void Main()
        {
            bool isTaskEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("{0, 85}", "ТУМАКОВ - ЛАБОРАТОРНАЯ РАБОТА №14. МЕНЮ ЗАДАНИЙ\n");
                Console.WriteLine("Подсказка:\n" +
                                  "Упражнение 14.1. Программа использует условный атрибут для условного выполнения кода                        -   цифра 1\n" +
                                  "Упражнение 14.2. Классу RationalNumber добавлен пользовательский атрибут                                    -   цифра 2\n" +
                                  "Домашнее задание 14.1. Классу Building добавлен пользовательский атрибуТ                                    -   цифра 3\n" +
                                  "Закончить выполнение заданий и выйти из программы                                                           -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        // Упражнение 14.1. Программа использует условный атрибут для условного выполнения кода.
                        Console.Clear();
                        Console.WriteLine("{0, 104}", "УПРАЖНЕНИЕ 14.1. ПРОГРАММА ИСПОЛЬЗУЕТ УСЛОВНЫЙ АТРИБУТ ДЛЯ УСЛОВНОГО ВЫПОЛНЕНИЯ КОДА\n");

                        BankAccount bankAccount = new BankAccount(AccountType.Текущий_счет);

                        Console.WriteLine("Результат выполнения кода без символа условной компиляции: ");
                        bankAccount.DumpToScreen();

                        Console.WriteLine("Результат выполнения кода с символом условной компиляции: ");
                        ConditionalAttributeCheck.CallingMethodDumpToScreen(bankAccount);

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        // Упражнение 14.2. Классу RationalNumber добавлен пользовательский атрибут.
                        Console.Clear();
                        Console.WriteLine("{0, 96}", "УПРАЖНЕНИЕ 14.2. КЛАССУ RationalNumber ДОБАВЛЕН ПОЛЬЗОВАТЬСКИЙ АТРИБУТ\n");

                        Console.Write("Чтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        // Домашнее задание 14.1. Классу Building добавлен пользовательский атрибут.
                        Console.Clear();
                        Console.WriteLine("{0, 96}", "ДОМАШНЕЕ ЗАДАНИЕ 14.1. КЛАССУ Building ДОБАВЛЕН ПОЛЬЗОВАТЬСКИЙ АТРИБУТ\n");

                        Console.Write("Чтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("{0, 71}", "ВЫ ВЫШЛИ ИЗ ПРОГРАММЫ");
                        isTaskEnd = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("{0, 99}", "ТАКОГО ЗАДАНИЯ НЕТ! ДОСТУПНЫЕ ЗАДАНИЯ УКАЗАНЫ В ПОДСКАЗКЕ. ПОВТОРИТЕ ПОПЫТКУ\n");
                        break;
                }
            } while (!isTaskEnd);
        }
    }
}