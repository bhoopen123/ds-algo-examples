// See https://aka.ms/new-console-template for more information
public class GreedySettlementStrategy : IExpenseSettlementStrategy
{
    public IEnumerable<Transaction> SettleBalanceSheet(IDictionary<string, int> balanceSheet)
    {
        PriorityQueue<UserForPriorityQueue, int> paidLess = new(new PriorityQueueComparer());
        PriorityQueue<UserForPriorityQueue, int> paidMore = new(new PriorityQueueComparer());
        List<Transaction> transactions = new();

        foreach (var (name, amount) in balanceSheet)
        {
            if (amount < 0)
            {
                paidLess.Enqueue(new UserForPriorityQueue(name, -amount), -amount); // make the amount positive
            }
            else if (amount > 0)
            {
                paidMore.Enqueue(new UserForPriorityQueue(name, amount), amount);
            }
        }

        while (paidLess.Count > 0)
        {
            var fromUser = paidLess.Dequeue();
            var toUser = paidMore.Dequeue();

            var transactionAmount = Math.Min(fromUser.Amount, toUser.Amount);
            transactions.Add(new Transaction(fromUser.Name, toUser.Name, transactionAmount));

            var fromUserNewAmount = fromUser.Amount - transactionAmount;
            var toUserNewAmount = toUser.Amount - transactionAmount;

            if (fromUserNewAmount > 0)
            {
                paidLess.Enqueue(new UserForPriorityQueue(fromUser.Name, fromUserNewAmount), fromUserNewAmount);
            }

            if (toUserNewAmount > 0)
            {
                paidMore.Enqueue(new UserForPriorityQueue(toUser.Name, toUserNewAmount), toUserNewAmount);
            }
        }

        return transactions;
    }

    public class PriorityQueueComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            // write comparision logic here
            return y - x;
        }
    }

}