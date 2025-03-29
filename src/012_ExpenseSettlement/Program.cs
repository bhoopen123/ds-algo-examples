// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

// Get data, 
// Prepare lists of PaidBies and SharedBies
IEnumerable<ExpensePaidBy> expensePaidBies = new List<ExpensePaidBy>
{
    new ExpensePaidBy("A", 4000),
    new ExpensePaidBy("B", 2000),
    new ExpensePaidBy("C", 6000),
};

IEnumerable<ExpenseSharedBy> expenseSharedBies = new List<ExpenseSharedBy>
{
    new ExpenseSharedBy("A", 1000),
    new ExpenseSharedBy("B", 1000),
    new ExpenseSharedBy("C", 1000),
    new ExpenseSharedBy("D", 1000),
    new ExpenseSharedBy("A", 1000),
    new ExpenseSharedBy("B", 1000),
    new ExpenseSharedBy("C", 3000),
    new ExpenseSharedBy("D", 3000),
};

var transactions = SettleExpenses(expensePaidBies, expenseSharedBies, new RoundTripSettlementStrategy());

foreach (var trans in transactions)
{
    Console.WriteLine(trans.ToString());
}

static IEnumerable<Transaction> SettleExpenses(IEnumerable<ExpensePaidBy> expensePaidBies,
                                            IEnumerable<ExpenseSharedBy> expenseSharedBies,
                                            IExpenseSettlementStrategy settlementStrategy)
{
    // create BalanceSheet
    IDictionary<string, int> balanceSheet = new Dictionary<string, int>();

    foreach (var expensePaidBy in expensePaidBies)
    {
        if (balanceSheet.ContainsKey(expensePaidBy.Name))
        {
            // update balanceSheet
            balanceSheet[expensePaidBy.Name] += expensePaidBy.Amount;
        }
        else
        {
            // add to balanceSheet
            // PaidBy amount is Positive
            balanceSheet.Add(expensePaidBy.Name, +expensePaidBy.Amount);
        }
    }

    foreach (var expenseSharedBy in expenseSharedBies)
    {
        if (balanceSheet.ContainsKey(expenseSharedBy.Name))
        {
            // update balanceSheet
            balanceSheet[expenseSharedBy.Name] -= expenseSharedBy.Amount;
        }
        else
        {
            // add to balanceSheet
            // SharedBy amount is Negative
            balanceSheet.Add(expenseSharedBy.Name, -expenseSharedBy.Amount);
        }
    }

    return settlementStrategy.SettleBalanceSheet(balanceSheet);
}