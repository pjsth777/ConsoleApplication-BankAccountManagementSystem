using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System
{
    public class CheckingAccount : BankAccount
    {
        private decimal overdraftlimit;

        public CheckingAccount(int accountNumber, string owner, decimal overdraftlimit) : base(accountNumber, owner)
        {
            this.overdraftlimit = overdraftlimit;
        }

        public override void Withdraw(decimal amount)
        {
            if (amount > 0 && Balance + overdraftlimit >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew: {amount:C} from account {AccountNumber}. Overdraft used: {Math.Max(0, -Balance):C}");
            }
            else
            {
                Console.WriteLine("Insufficient balance or overdraft limit reached.");
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" (Checking Account, Overdraft Limit: {overdraftlimit:C})";
        }
    }
}




