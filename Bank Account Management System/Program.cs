using Bank_Account_Management_System;
using System;
using System.Collections.Generic;

class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();
    static int accountNumberCounter = 1;

    static void Main(string[] args)
    {
        bool running = true;

        while(running)
        {
            Console.WriteLine("\nBank Account Management System");
            Console.WriteLine("1. Create a new account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Show account details");
            Console.WriteLine("5. Show transaction history");
            Console.WriteLine("6. Apply interest (Savings only)");
            Console.WriteLine("7. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    Deposit();
                    break;
                case "3":
                    Withdraw();
                    break;
                case "4":
                    ShowAccountDetails();
                    break;
                case "5":
                    ShowTransactionHistory();
                    break;
                case "6":
                    ApplyInterest();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again");
                    break;
            }
        }
    }

    static void CreateAccount()
    {
        Console.WriteLine("Enter owner name: ");
        string owner = Console.ReadLine();

        Console.WriteLine("Choose account type: 1. Savings 2. Checking");
        string accountType = Console.ReadLine();

        if (accountType == "1")
        {
            Console.Write("Enter interest rate: ");
            decimal interestRate = decimal.Parse(Console.ReadLine());

            BankAccount account = new SavingsAccount(accountNumberCounter++, owner, interestRate);
            accounts.Add(account);
        }
        else if (accountType == "2")
        {
            Console.Write("Enter overdraft limit: ");
            decimal overdraftlimit = decimal.Parse(Console.ReadLine());

            BankAccount account = new CheckingAccount(accountNumberCounter++, owner, overdraftlimit);
            accounts.Add(account);
        }

        Console.WriteLine("Account created successfully.");
    }

    static BankAccount GetAccountByNumber(int accountNumber)
    {
        return accounts.Find(acc => acc.AccountNumber == accountNumber);
    }

    static void Deposit()
    {
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());

        BankAccount account = GetAccountByNumber(accountNumber);
        if (account != null)
        {
            Console.Write("Enter deposit amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            account.Deposit(amount);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    static void Withdraw()
    {
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());

        BankAccount account = GetAccountByNumber(accountNumber);
        if (account != null)
        {
            Console.Write("Enter withdrawal amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            account.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    static void ShowAccountDetails()
    {
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());

        BankAccount account = GetAccountByNumber(accountNumber);
        if (account != null)
        {
            Console.WriteLine(account);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    static void ShowTransactionHistory()
    {
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());

        BankAccount account = GetAccountByNumber(accountNumber);
        if (account != null)
        {
            account.ShowTransactionHistory();
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    static void ApplyInterest()
    {
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());

        BankAccount account = GetAccountByNumber(accountNumber);
        if (account != null && account is SavingsAccount savingsAccount)
        {
            savingsAccount.ApplyInterest();
        }
        else
        {
            Console.WriteLine("This account is not a savings account or account not found.");
        }
    }
}

