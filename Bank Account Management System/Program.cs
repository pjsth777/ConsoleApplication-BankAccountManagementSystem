using Bank_Account_Management_System;
using System;
using System.Collections.Generic;

class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();

    // -------------------------------------------------------------------------------------------------------

    static void Main(string[] args)
    {

        LoadAccountsFromFile(); // Loads accounts when program starts

        bool running = true;

        while(running)
        {
            Console.WriteLine("\nBank Account Management System");
            Console.WriteLine("1. Create Savings account");
            Console.WriteLine("2. Create Checking account");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Show account details");
            Console.WriteLine("6. Show transaction history");
            Console.WriteLine("7. Apply interest to Savings Account");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateSavingsAccount();
                    break;
                case "2":
                    CreateCheckingAccount();
                    break;
                case "3":
                    Deposit();
                    break;
                case "4":
                    Withdraw();
                    break;
                case "5":
                    ShowAccountDetails();
                    break;
                case "6":
                    ShowTransactionHistory();
                    break;
                case "7":
                    ApplyInterest();
                    break;
                case "8":
                    running = false;
                    SaveAccountsToFile();
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again");
                    break;
            }
        }
    }

    // -------------------------------------------------------------------------------------------------------

    static void CreateSavingsAccount()
    {
        Console.WriteLine("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter owner name: ");
        string owner = Console.ReadLine();
        SavingsAccount account = new SavingsAccount(accountNumber, owner, 3.5m);
        accounts.Add(account);
        Console.WriteLine("Savings Account created successfully.");
    }

    // -------------------------------------------------------------------------------------------------------

    static void CreateCheckingAccount()
    {
        Console.WriteLine("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter owner name: ");
        string owner = Console.ReadLine();
        CheckingAccount account = new CheckingAccount(accountNumber, owner, 500m);
        accounts.Add(account);
        Console.WriteLine("Checking Account created successfully.");
    }

    // -------------------------------------------------------------------------------------------------------

    static void Deposit()
    {
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());

        BankAccount account = GetAccountByNumber(accountNumber);
        if (account != null)
        {
            Console.Write("Enter amount to deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            account.Deposit(amount);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    // -------------------------------------------------------------------------------------------------------

    static void Withdraw()
    {
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());

        BankAccount account = GetAccountByNumber(accountNumber);
        if (account != null)
        {
            Console.Write("Enter amount to withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            account.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    // -------------------------------------------------------------------------------------------------------

    static void ShowAccountDetails()
    {
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());

        BankAccount account = GetAccountByNumber(accountNumber);
        if (account != null)
        {
            Console.WriteLine(account.GetAccountDetails());
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    // -------------------------------------------------------------------------------------------------------

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

    // -------------------------------------------------------------------------------------------------------

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

    // -------------------------------------------------------------------------------------------------------

    static BankAccount GetAccountByNumber(int accountNumber)
    {
        return accounts.Find(acc => acc.AccountNumber == accountNumber);
    }

    // -------------------------------------------------------------------------------------------------------

    static void SaveAccountsToFile()
    {
        using (StreamWriter writer = new StreamWriter("accounts.txt"))
        {
            foreach(var account in accounts)
            {
                writer.WriteLine($"{account.GetType().Name}|{account.AccountNumber}|{account.Owner}|{account.Balance}");
                writer.WriteLine(string.Join(",", account.GetTransactionHistory()));
            }
        }
    }

    // -------------------------------------------------------------------------------------------------------

    static void LoadAccountsFromFile()
    {
        if (!File.Exists("accounts.txt"))
        {
            Console.WriteLine("No existing account data found.");
            return;
        }

        using (StreamReader reader = new StreamReader("accounts.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var accountData = line.Split("|");
                string accountType = accountData[0];
                int accountNumber = int.Parse(accountData[1]);
                string owner = accountData[2];
                decimal balance = decimal.Parse(accountData[3]);

                BankAccount account = null;

                if (accountType == nameof(SavingsAccount))
                {
                    account = new SavingsAccount(accountNumber, owner, 3.5m);
                }
                else if (accountType == nameof(CheckingAccount))
                {
                    account = new CheckingAccount(accountNumber, owner, 500m);
                }

                if (account != null)
                {
                    account.Deposit(balance);

                    string transactionHistory = reader.ReadLine();
                    var transactions = transactionHistory.Split(",");

                    foreach(var transaction in transactions)
                    {
                        account.AddTransaction(transaction);
                    }
                    accounts.Add(account);
                }
            }
        }
    }

    // -------------------------------------------------------------------------------------------------------

}

