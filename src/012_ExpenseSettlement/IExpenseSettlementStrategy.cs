// See https://aka.ms/new-console-template for more information
interface IExpenseSettlementStrategy
{
    IEnumerable<Transaction> SettleBalanceSheet(IDictionary<string, int> balanceSheet);
}
