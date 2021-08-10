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

        /*      public string Description(Transaction)
                {
                    return Bannerize($"{Type} of ${Amount} to {Account}");
                }

                // Behavior
                //
                // Name:     Bannerize (not bruce/Hunk, but with stars)
                // Input:    string
                // Output:   string (but with stars)
                // Work:     Make a string of stars then the input then more stars
                // Access:   Does the outside world need to access this? false
                private string Bannerize(string message)
                {
                    return "********************************\n" + message + "\n" + "********************************\n";
                }
        */



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




            //Checking Balance
            var totalCheckingDeposits = transactions.Where(transaction => transaction.Account == "Checking" && transaction.Type == "Deposit").Sum(transaction => transaction.Amount);

            var totalCheckingWithdraw = transactions.Where(transaction => transaction.Account == "Checking" && transaction.Type == "Withdraw").Sum(transaction => transaction.Amount);

            var checkingBalance = totalCheckingDeposits - totalCheckingWithdraw;

            //Savings Balance
            var totalSavingsDeposits = transactions.Where(transaction => transaction.Account == "Savings" && transaction.Type == "Deposit").Sum(transaction => transaction.Amount);

            var totalSavingsWithdraw = transactions.Where(transaction => transaction.Account == "Savings" && transaction.Type == "Withdraw").Sum(transaction => transaction.Amount);

            var savingsBalance = totalSavingsDeposits - totalSavingsWithdraw;


            DisplayGreeting();

            var userChoice = Console.ReadLine();

            var keepGoing = true;

            while (keepGoing)
            {
                if (userChoice == "7")
                {
                    keepGoing = false;
                    Console.WriteLine("Thank you for choosing First Bank of Suncoast!\n\n");
                    break;
                }

                else

                if (userChoice == "1")

                {
                    transaction.Date = DateTime.Now;
                    transaction.Account = "Checking";
                    transaction.Type = "Deposit";
                    transaction.Amount = PromptForInteger("Amount: $ ");

                    transactions.Add(transaction);

                    Console.WriteLine("\n\n######## -RECEIPT- ########\n\n");
                    Console.WriteLine("Transaction Approved\n");
                    Console.WriteLine($"Date: {DateTime.Now}");
                    Console.WriteLine($"Account: {transaction.Account}");
                    Console.WriteLine($"Transaction: {transaction.Type}");
                    Console.WriteLine($"Amount: ${transaction.Amount}");
                    Console.WriteLine($"Balance: ${checkingBalance}");
                    Console.WriteLine("\nThank you for banking with First Bank of Suncoast\n");
                    break;

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
                        break;
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
                        Console.WriteLine($"Balance: ${checkingBalance}\n");
                        Console.WriteLine("\nThank you for banking with First Bank of Suncoast\n");
                        break;
                    }

                }

                else if (userChoice == "3")

                {
                    {
                        Console.WriteLine($"Your balance is ${checkingBalance}");

                        break;

                    }

                    //Console.WriteLine($"There are {transaction.Count} transactions");

                    //For each transaction in our list of transactions
                    //foreach (var transaction in transactions)

                    {
                        // - Make a description of that transaction
                        //var descriptionOfTransaction = transaction.Description();

                        // - print that description to the user
                        //Console.WriteLine(descriptionOfTransaction);



                    }

                }

                else if (userChoice == "4")

                {
                    transaction.Date = DateTime.Now;
                    transaction.Account = "Savings";
                    transaction.Type = "Deposit";
                    transaction.Amount = PromptForInteger("Amount: $ ");

                    transactions.Add(transaction);

                    Console.WriteLine("\n\n######## -RECEIPT- ########\n\n");
                    Console.WriteLine($"Date: {DateTime.Now}");
                    Console.WriteLine($"Account: {transaction.Account}");
                    Console.WriteLine($"Transaction: {transaction.Type}");
                    Console.WriteLine($"Amount: ${transaction.Amount}");
                    Console.WriteLine($"Balance: {savingsBalance}\n");
                    Console.WriteLine("\nThank you for banking with First Bank of Suncoast\n");
                    break;

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
                        break;
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
                        break;

                    }
                }

                else if (userChoice == "6")

                {

                    //- Use LINQ .Where for Account = Savings
                    var statementSavings = transactions.Where(transaction => transaction.Account == "Savings");

                    foreach (var statementSavings in transactions)

                    {
                        //- Console.WriteLine the line listing each transaction
                        //- loop generating the following:
                        //- Account, Transaction, Amount
                        Console.WriteLine($"\n{statementSavings.Account}, {statementSavings.Type}, {statementSavings.Amount}");
                    }

                    //- Tally transactions to determine balance.
                    //- Console.WriteLine the Balance: $
                    Console.WriteLine($"Your savings account balance is ${savingsBalance}\n\n");
                    Console.WriteLine("Thank you for banking with First Bank of Suncoast");

                    // - Return to menu
                    break;

                }


            }

            var fileWriter = new StreamWriter("transactions.csv");
            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(transactions);
            fileWriter.Close();
        }

    }
}



