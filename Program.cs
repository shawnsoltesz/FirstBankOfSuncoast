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
        static int PromptForNegativeInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput * -1;
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
            // var areAnyOldMovies = movies.Any(movie => movie.ReleasedDate.Year < 1965);
            //var NewCheckingBalance = transactions.Sum(transaction.Account => transaction.Account = "Checking");

            //- new var checkingBalance = LINQ expression Sum = Checking, to gather all transactions for Account - Checking.
            //- Tally transactions to determine balance.
            //- Console.WriteLine the line listing each transaction

            var checkingBalance = 0;

            {
                if (transaction.Account == "Checking" && transaction.Type == "Deposit")

                {
                    checkingBalance += transaction.Amount;
                }

                if (transaction.Account == "Checking" && transaction.Type == "Withdraw")

                {
                    checkingBalance -= transaction.Amount;
                }

            }

            var savingsBalance = (0);

            foreach (var Transaction in transactions)

            {
                if (transaction.Account == "Savings" && transaction.Type == "Deposit")

                {
                    savingsBalance += transaction.Amount;
                }

                if (transaction.Account == "Savings" && transaction.Type == "Withdraw")

                {
                    savingsBalance -= transaction.Amount;
                }
            }

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
                    transaction.Amount = PromptForNegativeInteger("Amount: $ ");

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
                    Console.WriteLine($"Your checking account balance is: {checkingBalance}");
                    break;
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
                    transaction.Amount = PromptForNegativeInteger("Amount: $ ");
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
                    Console.WriteLine($"Your savings account balance is: {savingsBalance}");
                    break;
                }

                else
                {

                    Console.WriteLine("\n\n\nThank you for banking with First Bank of Suncoast");
                    keepGoing = false;
                }
            }

            var fileWriter = new StreamWriter("transactions.csv");
            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(transactions);
            fileWriter.Close();
        }

    }
}



