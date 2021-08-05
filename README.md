# FirstBankOfSuncoast

P -

We need to create our own personal bank account manager for First Bank of Suncoast. The single app requires functionality to allow us to complete and track a series of deposit and withdraw transactions for both accounts along with account balance, while retaining a history of the transactions conducted each time the app is used. Transactions cannot proceed if it will bring an account into a negative balance. Additional functionality will be generating a history or statement of all transactions for both accounts stored within the data.

Additionally, the app needs to leverage the transaction history data through maintaining an ongoing history in a file using a CSV format so that each time the app is started, the data is reloaded into the computer's memory for continuity purposes.

E -

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
