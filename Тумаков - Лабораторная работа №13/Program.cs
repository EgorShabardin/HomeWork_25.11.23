using System;

namespace Тумаков___Лабораторная_работа__13
{
    class Program
    {
        static void Main()
        {
            bool isTaskEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("{0, 85}", "ТУМАКОВ - ЛАБОРАТОРНАЯ РАБОТА №13. МЕНЮ ЗАДАНИЙ\n");
                Console.WriteLine("Подсказка:\n" +
                                  "Упражнение 13.1 и 13.2. В классы BankAccount и BankTransaction добавлены свойства и индексаторы             -   цифра 1\n" +
                                  "Д/З 13.1 и 13.2. В класс Building добавлены свойства. Создан класс CollectionOfBuildings с индексатором     -   цифра 2\n" +
                                  "Закончить выполнение заданий и выйти из программы                                                           -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        // Упражнение 13.1 и 13.2. В классы BankAccount и BankTransaction добавлены свойства и индексаторы.
                        Console.Clear();
                        Console.WriteLine("{0, 108}", "УПРАЖНЕНИЕ 13.1 И 13.2. В КЛАССЫ BankAccount И BankTransaction ДОБАВЛЕНЫ СВОЙСТВА И ИНДЕКСАТОРЫ\n");

                        BankAccount bankAccount = new BankAccount(AccountType.Сберегательный_счет);

                        Console.WriteLine($"{bankAccount.BankAccountType} под номером {bankAccount.AccountNumber:D4}: {bankAccount.AccountBalance} рублей. Владелец: {bankAccount.BankAccountHolder}");

                        bankAccount.PutMoneyIntoAccount(10000);
                        bankAccount.WithdrawMoneyFromAccount(500);

                        Console.WriteLine("\nТранзакции:");
                        for (int i = 0; i < bankAccount.TransactionList.Count; i++)
                        {
                            Console.WriteLine($"{bankAccount[i].AmountChange}, {bankAccount[i].TransactionDate}");
                        }

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        // Домашнее задание 13.1 и 13.2. В класс Building добавлены свойства. Создан класс CollectionOfBuildings с индексатором.
                        Console.Clear();
                        Console.WriteLine("{0, 119}", "ДОМАШНЕЕ ЗАДАНИЕ 13.1 И 13.2. В КЛАСС Building ДОБАВЛЕНЫ СВОЙСТВА. СОЗДАН КЛАСС CollectionOfBuildings С ИНДЕКСАТОРОМ\n");

                        CollectionOfBuildings collectionOfBuildings = new CollectionOfBuildings();

                        collectionOfBuildings.AddingBuildingToArray(new Building(5, 2, 30, 2));
                        collectionOfBuildings.AddingBuildingToArray(new Building(4, 2, 32, 3));
                        collectionOfBuildings.AddingBuildingToArray(new Building(6, 3, 37, 5));
                        collectionOfBuildings.AddingBuildingToArray(new Building(8, 4, 31, 2));
                        collectionOfBuildings.AddingBuildingToArray(new Building(10, 5, 10, 1));
                        collectionOfBuildings.AddingBuildingToArray(new Building(12, 5, 19, 3));
                        collectionOfBuildings.AddingBuildingToArray(new Building(4, 2, 17, 5));
                        collectionOfBuildings.AddingBuildingToArray(new Building(13, 3, 21, 4));
                        collectionOfBuildings.AddingBuildingToArray(new Building(14, 8, 14, 1));
                        collectionOfBuildings.AddingBuildingToArray(new Building(8, 2, 17, 1));

                        for (int i = 0; i < collectionOfBuildings.BuildingsArray.Length; i++)
                        {
                            Console.WriteLine($"Высота: {collectionOfBuildings[i].BuildingHeight}, количество квартир {collectionOfBuildings[i].NumberOfApartments}, номер дома: " +
                                              $"{collectionOfBuildings[i].BuildingNumber:D4}");
                        }

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
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