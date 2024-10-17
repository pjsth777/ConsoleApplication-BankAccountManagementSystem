using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System
{
    public class SavingsAccount : BankAccount
    {
        private decimal interestRate;

        public SavingsAccount(int accountNumber, string owner, decimal interestRate) : base(accountNumber, owner)
        {
            this.interestRate = interestRate;
        }

        public void ApplyInterest()
        {
            decimal interest = Balance * interestRate / 100;
            Deposit(interest);
            Console.WriteLine($"Applied {interestRate}% interest. New balance: {Balance:C}");
        }

        public override string ToString()
        {
            return base.ToString() + $" (Savings Account, Interest Rate: {interestRate}%)";
        }
    }
}
