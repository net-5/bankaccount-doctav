using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountApp
{
    class BankAccount : GeneralAccount, IAccountOperations
    {
        public enum ACCOUNT_STATUS { OPEN, CLOSED };

        private decimal balance;
        private Owner owner;
        private ACCOUNT_STATUS accountStatus;
        private List<Operation> listaOperatii;

        public List<Operation> ListaOperatii
        {
            get { return listaOperatii; }
            private set { listaOperatii = value; }
        }


        public ACCOUNT_STATUS AccountStatus
        {
            get { return accountStatus; }
            set { accountStatus = value; }
        }


        public Owner Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            protected set { balance = value; }
        }

        public BankAccount(string accountID, Owner owner, DateTime creationDate) : base(accountID, creationDate)
        {
            this.Owner = owner;
            OpenAccount();
            this.Balance = 0;  //initial amount
        }

        public void DepositMoney(decimal amount)
        {
            if (this.AccountStatus == ACCOUNT_STATUS.OPEN && amount >= 0)  //depunerea trebuie sa fie mereu cu valoarea pozitiva; nu acceptam "depuneri negative"
            {
                this.Balance = this.Balance + amount;
                this.ListaOperatii.Add(new Operation(Operation.OPERATION_TYPE.DEPOSIT, amount));  //adaug in istoricul operatiilor pe cea curenta
            }
        }

        public void WithdrawMoney(decimal amount)
        {
            if (this.AccountStatus == ACCOUNT_STATUS.OPEN && amount >= 0)  //retragerea trebuie sa fie mereu cu valoarea pozitiva; nu acceptam "retrageri negative" deoarece ar fi de fapt niste depuneri
            {
                this.Balance = this.Balance - amount;
                this.ListaOperatii.Add(new Operation(Operation.OPERATION_TYPE.WITHDRAWAL, amount));
            }
        }

        public void CloseAccount()
        {
            this.AccountStatus = ACCOUNT_STATUS.CLOSED;
        }

        public void OpenAccount()
        {
            this.AccountStatus = ACCOUNT_STATUS.OPEN;  //pe ideea ca un cont inchis poate fi redeschis la un moment dat (de exemplu, daca este in litigiu intre mostenitori sau cu ANAF
        }

        public void PrintAccountOperations()
        {
            Console.WriteLine($"Lista operatii pentru contul {this.AccountID}, titular {this.Owner}, stare {this.AccountStatus}");
            foreach (var operatie in ListaOperatii)
            {
                Console.WriteLine($"Tip tranzactie: {operatie.OperationType}, valoare: {operatie.OperationAmount}");
            }
            Console.WriteLine($"Sold final: {this.Balance}");
            Console.WriteLine($"Numar total de tranzactii: {this.ListaOperatii.Count}");
        }
    }
}
