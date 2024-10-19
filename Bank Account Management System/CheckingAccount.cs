using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Management_System
{
    public class CheckingAccount : BankAccount
    {
        public decimal OverDraftLimit { get; private set; }

        // -------------------------------------------------------------------------------------------------------

        public CheckingAccount(int accountNumber, string owner, decimal overdraftlimit) : base(accountNumber, owner)
        {
            OverDraftLimit = overdraftlimit;
        }

        // -------------------------------------------------------------------------------------------------------

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance + OverDraftLimit)
            {
                Console.WriteLine("Invalid withdrawal amount or exceeds overdraft limit.");
                return;
            }
            Balance -= amount;
            Console.WriteLine($"Withdrawal: {amount}");
        }

        // -------------------------------------------------------------------------------------------------------
    }
}




