using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        public DateTime Date { get; set; }
        public string Account { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
    }
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("\n\n");

            Console.WriteLine("   Welcome to First Bank of Suncoast  ");
            Console.WriteLine("    * * * * * * * * * * * * * * * * \n");
            Console.WriteLine("             Account Manager        \n");
            Console.WriteLine("    *-*-*-*-*-*-*-MENU-*-*-*-*-*-*  \n");

            Console.WriteLine("CHECKING ACCOUNT\n");

            Console.WriteLine("(1.) Checking Deposit");
            Console.WriteLine("(2.) Checking Withdraw");
            Console.WriteLine("(3.) Checking Balance Statement\n");

            Console.WriteLine("SAVINGS ACCOUNT\n");

            Console.WriteLine("(4.) Savings Deposit");
            Console.WriteLine("(5.) Savings Withdraw");
            Console.WriteLine("(6.) Savings Balance Statement\n");
            Console.WriteLine("(7.) Quit application\n");

            Console.WriteLine("Please input the number from the menu and press ENTER.\n");

        }
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;

        }
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                //Console.WriteLine("This is not a valid entry. Action cancelled.");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            var transactions = new List<Transaction>();

            if (File.Exists("transactions.csv"))

            {
                var fileReader = new StreamReader("transactions.csv");

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)

                {
                    HasHeaderRecord = true,
                };

                var csvReader = new CsvReader(fileReader, config);

                transactions = csvReader.GetRecords<Transaction>().ToList();

            }

            var transaction = new Transaction();

            var date = new DateTime(2008, 3, 15);

            var keepGoing = true;

            while (keepGoing)
            {
                DisplayGreeting();

                var userChoice = Console.ReadLine();

                if (userChoice == "7")
                {
                    keepGoing = false;
                    Console.WriteLine("Thank you for choosing First Bank of Suncoast!\n\n");
                }

                else

                if (userChoice == "1")

                {
                    transaction.Date = DateTime.Now;
                    transaction.Account = "Checking";
                    transaction.Type = "Deposit";
                    transaction.Amount = PromptForInteger("Amount: $ ");

                    transactions.Add(transaction);

                    //Checking Balance
                    int receiptCheckingBalance = ComputeCheckingBalance(transactions);

                    Console.WriteLine("\n\n######## -RECEIPT- ########\n\n");
                    Console.WriteLine("Transaction Approved\n");
                    Console.WriteLine($"Date: {DateTime.Now}");
                    Console.WriteLine($"Account: {transaction.Account}");
                    Console.WriteLine($"Transaction: {transaction.Type}");
                    Console.WriteLine($"Amount: ${transaction.Amount}");
                    Console.WriteLine($"Balance: ${receiptCheckingBalance}");
                    Console.WriteLine("\nThank you for banking with First Bank of Suncoast\n");
                }

                else

                if (userChoice == "2")

                {
                    transaction.Date = DateTime.Now;
                    transaction.Account = "Checking";
                    transaction.Type = "Withdraw";
                    transaction.Amount = PromptForInteger("Amount: $ ");

                    //- Check balance report for available funds
                    // - Tally all transaction amounts through the new variable amount from savings account running balance (var checkingBalance).
                    //- Deduct transaction amount from balance
                    var checkingBalance = ComputeCheckingBalance(transactions);

                    var withdrawApproval = transaction.Amount - checkingBalance;

                    if (withdrawApproval > 0)

                    {
                        //If negative balance is >0 = insufficient funds:

                        //- Print Receipt
                        //- cancel transaction

                        Console.WriteLine("\n\n######## -RECEIPT- ########\n\n");
                        Console.WriteLine("**Transaction Declined**");
                        Console.WriteLine("Reason: Insufficient Funds\n");
                        Console.WriteLine($"Date: {transaction.Date}");
                        Console.WriteLine($"Account: {transaction.Account}");
                        Console.WriteLine($"Transaction: {transaction.Type}");
                        Console.WriteLine($"Amount: ${transaction.Amount}");
                        Console.WriteLine($"Balance: ${checkingBalance}\n");
                        Console.WriteLine("\nThank you for banking with First Bank of Suncoast\n");
                    }

                    //If positive balance is <=0 = approved:

                    else

                    {
                        //- create a transaction entry as a negative value
                        //- print Receipt

                        transactions.Add(transaction);
                        //need to update the csv to reflect in the {checkingBalance} below

                        Console.WriteLine("\n\n######## -RECEIPT- ########\n\n");
                        Console.WriteLine("Transaction Approved\n");
                        Console.WriteLine($"Date: {transaction.Date}");
                        Console.WriteLine($"Account: {transaction.Account}");
                        Console.WriteLine($"Transaction: {transaction.Type}");
                        Console.WriteLine($"Amount: ${transaction.Amount}");
                        Console.WriteLine($"Balance: ${checkingBalance}\n");
                        Console.WriteLine("\nThank you for banking with First Bank of Suncoast\n");
                    }
                }

                else if (userChoice == "3")

                {
                    {
                        var statementChecking = transactions.Where(transaction => transaction.Account == "Checking");

                        foreach (var checkingTransaction in statementChecking)
                        {
                            //- Console.WriteLine the line listing each transaction
                            //- loop generating the following linelisted:
                            //- Account, Transaction, Amount
                            Console.WriteLine($"\n{checkingTransaction.Account}, {checkingTransaction.Type}, ${checkingTransaction.Amount}");
                        }

                        var checkingBalance = ComputeCheckingBalance(transactions);

                        //- Tally transactions to determine balance.
                        //- Console.WriteLine the Balance: $
                        Console.WriteLine($"\nYour checking account balance is ${checkingBalance}\n\n");
                        Console.WriteLine("Thank you for banking with First Bank of Suncoast");
                        // - Return to menu

                    }
                }

                else if (userChoice == "4")

                {
                    transaction.Date = DateTime.Now;
                    transaction.Account = "Savings";
                    transaction.Type = "Deposit";
                    transaction.Amount = PromptForInteger("Amount: $ ");

                    transactions.Add(transaction);
                    //need to update the csv to reflect in the {savingsBalance} below

                    int savingsBalance = ComputeSavingsBalance(transactions);

                    Console.WriteLine("\n\n######## -RECEIPT- ########\n\n");
                    Console.WriteLine($"Date: {DateTime.Now}");
                    Console.WriteLine($"Account: {transaction.Account}");
                    Console.WriteLine($"Transaction: {transaction.Type}");
                    Console.WriteLine($"Amount: ${transaction.Amount}");
                    Console.WriteLine($"Balance: {savingsBalance}\n");
                    Console.WriteLine("\nThank you for banking with First Bank of Suncoast\n");
                }

                else if (userChoice == "5")

                {
                    transaction.Date = DateTime.Now;
                    transaction.Account = "Savings";
                    transaction.Type = "Withdraw";
                    transaction.Amount = PromptForInteger("Amount: $ ");
                    //- Check balance report for available funds
                    // - Tally all transaction amounts through the new variable amount from savings account running balance (var checkingBalance).
                    //- Deduct transaction amount from balance

                    int savingsBalance = ComputeSavingsBalance(transactions);

                    var withdrawApproval = transaction.Amount - savingsBalance;

                    if (withdrawApproval > 0)

                    {
                        //If negative balance is >0 = insufficient funds:

                        //- Print Receipt
                        //- cancel transaction

                        Console.WriteLine("\n\n######## -RECEIPT- ########\n\n");
                        Console.WriteLine("**Transaction Declined**");
                        Console.WriteLine("Reason: Insufficient Funds\n");
                        Console.WriteLine($"Date: {transaction.Date}");
                        Console.WriteLine($"Account: {transaction.Account}");
                        Console.WriteLine($"Transaction: {transaction.Type}");
                        Console.WriteLine($"Amount: ${transaction.Amount}");
                        Console.WriteLine($"Balance: ${savingsBalance}\n");
                        Console.WriteLine("\nThank you for banking with First Bank of Suncoast\n");

                    }

                    //If positive balance is <=0 = approved:

                    else

                    {
                        //- create a transaction entry as a negative value
                        //- print Receipt

                        transactions.Add(transaction);

                        Console.WriteLine("\n\n######## -RECEIPT- ########\n\n");
                        Console.WriteLine("Transaction Approved\n");
                        Console.WriteLine($"Date: {transaction.Date}");
                        Console.WriteLine($"Account: {transaction.Account}");
                        Console.WriteLine($"Transaction: {transaction.Type}");
                        Console.WriteLine($"Amount: ${transaction.Amount}");
                        Console.WriteLine($"Balance: ${savingsBalance}\n");
                        Console.WriteLine("\nThank you for banking with First Bank of Suncoast\n");
                    }
                }

                else if (userChoice == "6")

                {

                    //- Use LINQ .Where for Account = Savings
                    var statementSavings = transactions.Where(transaction => transaction.Account == "Savings");

                    foreach (var savingTransaction in statementSavings)
                    {
                        //- Console.WriteLine the line listing each transaction
                        //- loop generating the following linelisted:
                        //- Account, Transaction, Amount
                        Console.WriteLine($"\n{savingTransaction.Account}, {savingTransaction.Type}, ${savingTransaction.Amount}");
                    }

                    //- Tally transactions to determine balance.
                    //- Console.WriteLine the Balance: $

                    int savingsBalance = ComputeSavingsBalance(transactions);

                    Console.WriteLine($"\nYour savings account balance is ${savingsBalance}\n\n");
                    Console.WriteLine("Thank you for banking with First Bank of Suncoast");
                    // - Return to menu

                }

                var fileWriter = new StreamWriter("transactions.csv");
                var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(transactions);
                fileWriter.Close();
            }
        }

        public static int ComputeSavingsBalance(List<Transaction> transactions)
        {
            //Savings Balance
            var totalSavingsDeposits = transactions.Where(transaction => transaction.Account == "Savings" && transaction.Type == "Deposit").Sum(transaction => transaction.Amount);
            var totalSavingsWithdraw = transactions.Where(transaction => transaction.Account == "Savings" && transaction.Type == "Withdraw").Sum(transaction => transaction.Amount);
            var savingsBalance = totalSavingsDeposits - totalSavingsWithdraw;
            return savingsBalance;
        }

        public static int ComputeCheckingBalance(List<Transaction> transactions)
        {
            var receiptCheckingDeposits = transactions.Where(transaction => transaction.Account == "Checking" && transaction.Type == "Deposit").Sum(transaction => transaction.Amount);
            var receiptCheckingWithdraw = transactions.Where(transaction => transaction.Account == "Checking" && transaction.Type == "Withdraw").Sum(transaction => transaction.Amount);
            var receiptCheckingBalance = receiptCheckingDeposits - receiptCheckingWithdraw;

            return receiptCheckingBalance;
        }
    }
}





