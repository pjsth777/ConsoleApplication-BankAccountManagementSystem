using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System
{
    public class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; private set; }

        // -------------------------------------------------------------------------------------------------------

        public SavingsAccount(int accountNumber, string owner, decimal interestRate) : base(accountNumber, owner)
        {
            InterestRate = interestRate;
        }

        // -------------------------------------------------------------------------------------------------------

        public void ApplyInterest()
        {
            decimal interest = Balance * InterestRate / 100;
            Deposit(interest);
            Console.WriteLine($"Interest applied: {interest:C}");
        }

        // -------------------------------------------------------------------------------------------------------

    }
}
