using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System
{
    public class BankAccount
    {
        public int AccountNumber { get; private set; }
        public string Owner { get; private set; }
        public decimal Balance { get; protected set; } // 'protected' so child classes can access it

        private List<string> transactions = new List<string>();

        public BankAccount(int accountNumber, string owner)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = 0;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                transactions.Add($"Deposited: {amount:C}");
                Console.WriteLine($"Deposited {amount:C} to account {AccountNumber}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                transactions.Add($"Withdrew: {amount:C}");
                Console.WriteLine($"Withdrew {amount:C} from account {AccountNumber}");
            }
            else
            {
                Console.WriteLine("Insufficient balance or invalid amount.");
            }
        }

        public void ShowTransactionHistory()
        {
            Console.WriteLine($"\nTransaction history for account {AccountNumber}:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        public override string ToString()
        {
            return $"Account: {AccountNumber}, Owner: {Owner}, Balance: {Balance:C}";
        }
    }
}
