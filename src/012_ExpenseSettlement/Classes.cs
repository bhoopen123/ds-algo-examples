// See https://aka.ms/new-console-template for more information
public record Transaction(string From, string To, int Amount)
{
    override public string ToString() => $"{From} owes {To} {Amount}";
}

public record ExpensePaidBy(string Name, int Amount);

public record ExpenseSharedBy(string Name, int Amount);

public class RoundTripSettlementStrategy : IExpenseSettlementStrategy
{
    public IEnumerable<Transaction> SettleBalanceSheet(IDictionary<string, int> balanceSheet)
    {
        List<Transaction> transactions = new();

        HashSet<string> users = balanceSheet.Keys.ToHashSet();

        for (int i = 0; i < users.Count - 1; i++)
        {
            string currentUser = users.ElementAt(i);
            string nextUser = users.ElementAt(i + 1);

            int currentUserBalance = balanceSheet[currentUser];
            int nextUserBalance = balanceSheet[nextUser];

            Transaction transaction = null;
            if (currentUserBalance > 0)
            {
                // 'current' has paid more, now 'next' should pay to 'current'
                int amount = currentUserBalance;
                transaction = new Transaction(nextUser, currentUser, amount);

                currentUserBalance -= amount;
                nextUserBalance += amount;
            }
            else
            {
                // 'current' has paid less, now 'current' should pay to 'next'
                int amount = -currentUserBalance;
                transaction = new Transaction(currentUser, nextUser, -currentUserBalance);

                currentUserBalance += amount;
                nextUserBalance -= amount;
            }

            balanceSheet[currentUser] = currentUserBalance;
            balanceSheet[nextUser] = nextUserBalance;

            transactions.Add(transaction);
        }

        return transactions;
    }
}

interface IExpenseSettlementStrategy
{
    IEnumerable<Transaction> SettleBalanceSheet(IDictionary<string, int> balanceSheet);
}