# FirstBankOfSuncoast

P -

We need to create our own personal bank account manager for First Bank of Suncoast. The single app requires functionality to allow us to complete and track a series of deposit and withdraw transactions for both accounts along with account balance, while retaining a history of the transactions conducted each time the app is used. Transactions cannot proceed if it will bring an account into a negative balance. Additional functionality will be generating a history or statement of all transactions for both accounts stored within the data.

Additionally, the app needs to leverage the transaction history data through maintaining an ongoing history in a file using a CSV format so that each time the app is started, the data is reloaded into the computer's memory for continuity purposes.

E -

Savings Deposit: Process a deposit in the amount of $20 and impact the account balance accordingly.

Savings Withdraw: Process a withdraw in the amount of $4 and impact the account balance accordingly. Convert the value to negative for easy of computing balance.

Savings Balance: use transaction list for withdraw and deposits to track and compute balance when needed. Using the two transaction examples above, and assuming the order is 1.) deposit and then 2.) withdraw, the balance should initially display $20 and then $16.

Checking Deposit: Process a deposit in the amount of $20 and impact the account balance accordingly.

Checking Withdraw: Process a withdraw in the amount of $4 and impact the account balance accordingly. Convert the value to negative for easy of computing balance.

Checking Balance: use transaction list for withdraw and deposits to track and compute balance when needed. Using the two transaction examples above, and assuming the order is 1.) deposit and then 2.) withdraw, the balance should initially display $20 and then $16.

No negative balance: in the event a withdraw transaction will cause the account balance to go negative, it needs to be declined. Therefore logic is needed to check the proposed transaction against the current balance of the specific account - checking or savings, to determine whether it is permissible. Example, if checking account has a balance of $16, but a transaction is processing for a $20 withdraw, the transaction should be declined.

The app will compute balances by examining all the transactions in the history. For instance, if a user deposits 10 to their savings, then withdraws 8 from their savings, then deposits 25 to their checking, they have three transactions to consider. Compute the checking and saving balance, using the transaction list, when needed. In this case, their savings balance is 2 and their checking balance is 25.

Ongoing transactions - need to keep Checking and Savings transactions separate, but tracked together in the SINGLE list <Transaction>

D - CREATE _ REMOVE _ UPDATE \* D

CSV file: the app must track transactions in its memory and upon completing each transaction. Have a second command to update CSV based on transactions while app was open. Then upon restarting the app, the data should be loaded to allow for instant and real time access to transaction history and account balances.

The application should store a history of transactions in a SINGLE List<Transaction>.

Design the <Transaction> class to support both checking and savings accounts, as well as deposit and withdraw transactions. (like the Blackjack app tracked dealer and player cards in one lists -

3. Date [Date]

   Date = DateTime.Now

4. Amount [integer]

   int transactionAmount = Console.ReadLine();

Receipt
Console.WriteLine = ("######## -RECEIPT- ########\n\n");
Console.WriteLine = ("$Date: {date}");
Console.WriteLine = ("$Account: {});
Console.WriteLine = ("$Transaction: {});
Console.WriteLine = ("$Amount: ${transactionAmount}\n");
Console.WriteLine = ("Thank you for banking with us!");

Balance Report (Use LINQ expressions to help with data)

Checking Account >

- Compile all Deposits and Withdraws for Checking
  -- Sort Ascending by Date

Savings Account >

- Compile all Deposits and Withdraws for Savings
  -- Sort Ascending by Date

// 3. Create a player hand
var player = new Hand();

// 4. Create a dealer hand
var dealer = new Hand();

// 5. Ask the deck for a card and place it in the player hand
// - the card is equal to the 0th index of the deck list
// 6. Ask the deck for a card and place it in the player hand
player.AddCards(deck.DealMultiple(2));

// 7. Ask the deck for a card and place it in the dealer hand
// 8. Ask the deck for a card and place it in the dealer hand
dealer.AddCards(deck.DealMultiple(2));)

Transaction History derived from one Transaction list: LINQ list capabilities

- User should be able to see the list of transactions designated savings.
- User should be able to see the list of transactions designated checking.

Memory and CSV file updates - The application should, after each transaction, write all the transactions to a file. This is the same file the application loads when the app is initiated.

Transaction Class -

Date
Account (Checking or Savings)
Type (Deposit or Withdraw)
Amount

List:

transactions = new List <Transaction>;

newTransaction = new Date ();
newTransaction = new Account ();
newTransaction = new Type ();
newTransaction = new Amount ();

A -

Display Greeting

Transaction options - display all on one screen, do not create a decision tree with multiple layers for a drill down to accomplish a task.

Checking

- 1. Menu option for user to make a deposit transaction for checking.
- 2. Menu option for user to make a withdraw transaction for checking.
- 3. Menu option for user to see the balance of checking account.

Savings

- 4. Menu option for user to make a deposit transaction for savings.
- 5. Menu option for user to make a withdraw transaction for savings.
- 6. Menu option for user to see the balance of savings account.

Transaction Flows based on menu options

1. Checking Deposit >

- Date, Account and Type auto set
- User enters amount >
- Create a transaction entry
- Print Receipt
  - include var "checkingBalance" computed for the balance/statement for Menu option #3
- Return to menu

2. Checking Withdraw >

- Date, Account and Type auto set
- User enters amount > convert to a negative value
  - Check balance report for available funds
    - Tally all transaction amounts through the new variable amount from savings account running balance (var checkingBalance).
    - Deduct transaction amount from balance

If negative balance is >0 = insufficient funds:

- cancel transaction
- Print Receipt
  - Need to add an extra line stating insufficient funds and transaction cancelled
    -include var "checkingBalance" computed for the balance/statement for computed balance.
  - Return to menu

If positive balance is <=0 = approved:

- create a transaction entry as a negative value
- print Receipt
- Return to menu

3. Checking Balance/Statement

- new var checkingBalance = LINQ expression bool true = Checking, to gather all transactions for Account - Checking.
  - Use bool true for Account = Checking
- Sort in Ascending order
- Tally transactions to determine balance.
- Console.WriteLine the line listing each transaction
  - loop generating the following:
    - Account, Transaction, Date, Amount
- Console.WriteLine the Balance: $X
- Return to menu

4. Savings Deposit >

- Date, Account and Type auto set
- User enters amount >
- Create a transaction entry
- Print Receipt
  - include var "savingsBalance" computed for the balance/statement for Menu option #6
- Return to menu

5. Savings Withdraw >

- Date, Account and Type auto set
- User enters amount > convert to a negative value
  - Check balance report for available funds
    - Tally all balances and deduct new variable amount from savings account running balance var savingsBalance. LINQ tally all <AccountT> for report

If negative balance is >0 - insufficient funds -

- cancel transaction
- Print Receipt
  - Need to add an extra line stating insufficient funds and transaction cancelled
- Return to menu

If positive balance is <=0 - approved = -

- create a transaction entry as a negative value
- Print receipt
  - include var "savingsBalance" computed for the balance/statement for Menu option #6
- Return to menu

6. Savings Balance/Statement

- new var checkingBalance = LINQ expression bool true = Savings, to gather all transactions for Account - Savings.
  - Use bool true for Account = Savings
- Sort in Ascending order
- Tally transactions to determine balance.
- Console.WriteLine the line listing each transaction
  - loop generating the following:
    - Account, Transaction, Date, Amount
- Console.WriteLine the Balance: $
- Return to menu

7. Quit

- Console.WriteLine("Goodbye!")
- break;

CSV adaptation
