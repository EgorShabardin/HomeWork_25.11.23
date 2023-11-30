using System.Collections.Generic;
using System.IO;
using System;

namespace Тумаков___Лабораторная_работа__13
{
    /// <summary>
    /// Перечислимый тип, содержащий виды банковских счетов.
    /// </summary>
    public enum AccountType
    {
        Текущий_счет,
        Сберегательный_счет
    }

    /// <summary>
    /// Класс, описывающий счет в банке.
    /// </summary>
    class BankAccount
    {
        #region Поля
        private static int numberOfBankAccounts;
        private int accountNumber;
        private decimal accountBalance;
        private string bankAccountHolder;
        private List<BankTransaction> transactionList = new List<BankTransaction>();
        private AccountType bankAccountType;
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство, позволяющее читать поле accountNumber.
        /// </summary>
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле accountBalance.
        /// </summary>
        public decimal AccountBalance
        {
            get
            {
                return accountBalance;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать и заполнять поле bankAccountHolder.
        /// </summary>
        public string BankAccountHolder
        {
            get
            {
                return bankAccountHolder;
            }
            set
            {
                bankAccountHolder = value;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле bankAccountType.
        /// </summary>
        public AccountType BankAccountType
        {
            get
            {
                return bankAccountType;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле transactionList.
        /// </summary>
        public List<BankTransaction> TransactionList
        {
            get
            {
                return transactionList;
            }
        }
        #endregion

        #region Индексаторы
        /// <summary>
        /// Индексатор, позволяющий получить доступ к любому объекту BankTransaction в списке.
        /// </summary>
        /// <param name="index"> Индекс объекта BankTransaction в списке. </param>
        /// <returns> Объект BankTransaction. </returns>
        public BankTransaction this[int index]
        {
            get
            {
                return transactionList[index];
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод, изменяющий количество банковских счетов (поле numberOfBankAccounts).
        /// </summary>
        private void ChangeNumberOfBankAccounts()
        {
            numberOfBankAccounts++;
        }

        /// <summary>
        /// Метод, снимающий некоторую денежную сумму с банковского счета.
        /// </summary>
        /// <param name="withdrawalAmount"> Денежная сумма, которую необходимо снять. </param>
        /// <returns> Возвращает true, если снятие денежной суммы возможно, иначе false. </returns>
        public bool WithdrawMoneyFromAccount(decimal withdrawalAmount)
        {
            if ((accountBalance - withdrawalAmount > 0) && (withdrawalAmount > 0))
            {
                accountBalance -= withdrawalAmount;
                BankTransaction bankTransaction = new BankTransaction(-withdrawalAmount);
                transactionList.Add(bankTransaction);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, пополняющий банковский счет на некоторую денежную сумму.
        /// </summary>
        /// <param name="depositedAmoun"> Денежная сумма, которую необходимо внести. </param>
        /// <returns> Возвращает true, если пополнение возможно, иначе false. </returns>
        public bool PutMoneyIntoAccount(decimal depositedAmoun)
        {
            if (depositedAmoun > 0)
            {
                accountBalance += depositedAmoun;
                BankTransaction bankTransaction = new BankTransaction(depositedAmoun);
                transactionList.Add(bankTransaction);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, позволяющий переводить деньги с одного счета на другой.
        /// </summary>
        /// <param name="withdrawalAccount"> Счет, с которого снимаются деньги. </param>
        /// <param name="withdrawalAmount"> Сумма снятия. </param>
        /// <returns> Возвращает true, если перевод денег возможен, иначе false. </returns>
        public bool TransferringMoney(BankAccount withdrawalAccount, decimal withdrawalAmount)
        {
            if ((withdrawalAmount > 0) && (withdrawalAccount.AccountBalance - withdrawalAmount > 0))
            {
                accountBalance += withdrawalAmount;
                withdrawalAccount.accountBalance -= withdrawalAmount;
                BankTransaction bankTransaction = new BankTransaction(-withdrawalAmount);
                transactionList.Add(bankTransaction);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, который данные о транзакциях записывает во внешний файл.
        /// </summary>
        /// <param name="bankAccount"> Банковский счет. </param>
        public void Dispose(BankAccount bankAccount)
        {
            for (int i = 0; i < transactionList.Count; i++)
            {
                BankTransaction transaction = transactionList[i];

                if (transaction.AmountChange < 0)
                {
                    File.AppendAllText("ProgramFiles/dispose.txt", $"Снятие {transaction.TransactionDate}, {-transaction.AmountChange} рублей".ToString() + Environment.NewLine);
                }
                else
                {
                    File.AppendAllText("ProgramFiles/dispose.txt", $"Пополнение {transaction.TransactionDate}, {transaction.AmountChange} рублей".ToString() + Environment.NewLine);
                }
            }

            transactionList = new List<BankTransaction>();
            GC.SuppressFinalize(bankAccount);
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, который создает экземпляр класса BankAccount и заполняет его данными.
        /// </summary>
        /// <param name="accountBalance"> Баланс банковского счета. </param>
        /// <param name="bankAccountHolder"> Держатель банковского счета. </param>
        public BankAccount(decimal accountBalance, string bankAccountHolder)
        {
            this.accountBalance = accountBalance;
            this.bankAccountHolder = bankAccountHolder;
            bankAccountType = AccountType.Текущий_счет;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }

        /// <summary>
        /// Конструктор, который создает экземпляр класса BankAccount и заполняет его данными.
        /// </summary>
        /// <param name="bankAccountType"> Тип банковского счета. </param>
        public BankAccount(AccountType bankAccountType)
        {
            this.bankAccountType = bankAccountType;
            accountBalance = 0;
            bankAccountHolder = "не указано";
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }

        /// <summary>
        /// Конструктор, который создает экземпляр класса BankAccount и заполняет его данными.
        /// </summary>
        /// <param name="accountBalance"> Баланс банковского счета. </param>
        /// <param name="bankAccountType"> Тип банковского счета. </param>
        public BankAccount(decimal accountBalance, AccountType bankAccountType)
        {
            this.accountBalance = accountBalance;
            this.bankAccountType = bankAccountType;
            bankAccountHolder = "не указано";
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }
        #endregion
    }
}

