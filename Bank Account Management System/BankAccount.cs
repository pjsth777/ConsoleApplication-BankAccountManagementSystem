using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System
{
    public class BankAccount
    {
        // -------------------------------------------------------------------------------------------------------
        public int AccountNumber { get; private set; }
        public string Owner { get; private set; }
        public decimal Balance { get; protected set; } // 'protected' so child classes can access it

        private List<string> transactions = new List<string>();

        // -------------------------------------------------------------------------------------------------------

        public BankAccount(int accountNumber, string owner)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = 0;
        }

        // -------------------------------------------------------------------------------------------------------

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }
            Balance += amount;
            transactions.Add($"Deposited: {amount:C}");
        }

        // -------------------------------------------------------------------------------------------------------

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                Console.WriteLine("Invalid withdrawal amount.");
                return;
            }
            Balance -= amount;
            transactions.Add($"Withdrawal: {amount:C}");
        }

        // -------------------------------------------------------------------------------------------------------

        public string GetAccountDetails()
        {
            return $"Account Number: {AccountNumber}, Owner: {Owner}, Balance: {Balance}";
        }

        // -------------------------------------------------------------------------------------------------------

        public void ShowTransactionHistory()
        {
            Console.WriteLine("Transaction History");
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        // -------------------------------------------------------------------------------------------------------
        
        public List<string> GetTransactionHistory()
        {
            return transactions;
        }
        
        // -------------------------------------------------------------------------------------------------------

        public void AddTransaction(string transaction)
        {
            transactions.Add(transaction);
        }

        // -------------------------------------------------------------------------------------------------------
    }
}
