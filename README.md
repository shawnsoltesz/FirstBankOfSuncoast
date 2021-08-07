# FirstBankOfSuncoast

P -

We need to create our own personal bank account manager for First Bank of Suncoast. The single app requires functionality to allow us to complete and track a series of deposit and withdraw transactions for both accounts along with account balance, while retaining a history of the transactions conducted each time the app is used. Transactions cannot proceed if it will bring an account into a negative balance. Additional functionality will be generating a history or statement of all transactions for both accounts stored within the data.

Additionally, the app needs to leverage the transaction history data through maintaining an ongoing history in a file using a CSV format so that each time the app is started, the data is reloaded into the computer's memory for continuity purposes.

E -

Savings Deposit: Process a deposit in the amount of $20 and impact the account balance accordingly.

Savings Withdraw: Process a withdraw in the amount of $4 and impact the account balance accordingly.

Savings Balance: use transaction list for withdraw and deposits to track and compute balance when needed. Using the two transaction examples above, and assuming the order is 1.) deposit and then 2.) withdraw, the balance should initially display $20 and then $16.

Checking Deposit: Process a deposit in the amount of $20 and impact the account balance accordingly.

Checking Withdraw: Process a withdraw in the amount of $4 and impact the account balance accordingly.

Checking Balance: use transaction list for withdraw and deposits to track and compute balance when needed. Using the two transaction examples above, and assuming the order is 1.) deposit and then 2.) withdraw, the balance should initially display $20 and then $16.

No negative balance: in the event a withdraw transaction will cause the account balance to go negative, it needs to be declined. Therefore logic is needed to check the proposed transaction against the current balance of the specific account - checking or savings, to determine whether it is permissible. Example, if checking account has a balance of $16, but a transaction is processing for a $20 withdraw, the transaction should be declined.

Ongoing transactions - need to keep Checking and Savings transactions separate, but tracked together in the SINGLE list <Transaction>

CSV file: the app must track transactions in its memory and upon completing each transaction. Have a second command to update CSV based on transactions while app was open. Then upon restarting the app, the data should be loaded to allow for instant and real time access to transaction history and account balances.

D - CREATE _ REMOVE _ UPDATE \* D

The app will compute balances by examining all the transactions in the history. For instance, if a user deposits 10 to their savings, then withdraws 8 from their savings, then deposits 25 to their checking, they have three transactions to consider. Compute the checking and saving balance, using the transaction list, when needed. In this case, their savings balance is 2 and their checking balance is 25.

The application should store a history of transactions in a SINGLE List<Transaction>.

Design the <Transaction> class to support both checking and savings accounts, as well as deposit and withdraw transactions. (like the Blackjack app tracked dealer and player cards in one lists -

Transaction Type includes:

1. Transaction Type [string]
   a. Deposit
   b. Withdraw

2. Account Type [string] - could be a bool, but only T/F options and not suitable for scale
   a. Checking
   b. Savings

3. Amount [integer]

4. Date [double]

Console.ReadLine for user to enter amount

Transaction Flows:
Checking Deposit >
User enters amount >
Create a transaction entry

Checking Withdraw >
User enters amount >
Check balance report for available funds
If approved,
create a transaction entry
deduct amount from balance
If denied, cancel transaction

Savings Deposit >
User enters amount >
Create a transaction entry

Savings Withdraw >
User enters amount >
Check balance report for available funds
If approved,
create a transaction entry
deduct amount from balance
If denied, cancel transaction

Balance Report (Use LINQ expressions to help with data)

Checking Account >
Compile all Deposits and Withdraws for Checking
Sort Ascending by Date

Savings Account >
Compile all Deposits and Withdraws for Savings
Sort Ascending by Date

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

A -

Display Greeting

- Welcome to First Bank of Suncoast

Transaction options - display all on one screen, do not create a decision tree with multiple layers for a drill down to accomplish a task.

- Menu option for user to make a deposit transaction for checking.
- Menu option for user to make a deposit transaction for savings.
- Menu option for user to make a withdraw transaction for checking.
- Menu option for user to make a withdraw transaction for savings.
- Menu option for user to see the balance of checking account.
- Menu option for user to see the balance of savings account.

(Potential Layout) -

Checking:

- Deposit
- Withdraw
- Balance

Savings:

- Deposit
- Withdraw
- Balance

Prevent a withdraw for an amount that is greater than the account balance. Neither checking or savings balances should never display a negative balance.

Account History: Console.WriteLine generated based on date range entered by customer through Console.Read. Use LINQ for sorting based on transaction date.

- Checking
- Savings

Statement (preformatted report that displays transaction history for last >= 30 days) Utilize LINQ expressions for pulling last 30 days and then sorting in ascending order.

- Checking
- Savings

When prompting for an amount to withdraw, always compare the amount against the balance to ensure the balance amount after the transaction remains positive. Negative balances are forbidden. Upon processing the transaction, the balance value we store in the Transaction list shall be positive as well. (e.g. a Transaction that is a withdraw of $25 both inputs and records a positive $25)
