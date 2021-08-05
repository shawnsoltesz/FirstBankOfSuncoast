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

CSV file: the app must track transactions in its memory and upon specific transaction commands, or upon closing the app, the memory needs to be written to the CSV file. Then upon restarting the app, the data should be loaded to allow for instant and real time access to transaction history and account balances.

D -

You will compute balances by examining all the transactions in the history. For instance, if a user deposits 10 to their savings, then withdraws 8 from their savings, then deposits 25 to their checking, they have three transactions to consider. Compute the checking and saving balance, using the transaction list, when needed. In this case, their savings balance is 2 and their checking balance is 25.

The application should store a history of transactions in a SINGLE List<Transaction>.

Your task is to design the Transaction class to support both checking and savings as well as deposits and withdraws.

The application should load past transactions from a file when it first starts.

As a user I should be able to see the list of transactions designated savings.

As a user I should be able to see the list of transactions designated checking.

Never allow withdrawing more money than is available. That is, we cannot allow our checking or savings balances to go negative.

When prompting for an amount to deposit or withdraw always ensure the amount is positive. The value we store in the Transaction shall be positive as well. (e.g. a Transaction that is a withdraw of 25 both inputs and records a positive 25)

As a user I should have a menu option to make a deposit transaction for savings.
As a user I should have a menu option to make a deposit transaction for checking.
As a user I should have a menu option to make a withdraw transaction for savings.
As a user I should have a menu option to make a withdraw transaction for checking.
As a user I should have a menu option to see the balance of my savings and checking.

The application should, after each transaction, write all the transactions to a file. This is the same file the application loads.

A -
