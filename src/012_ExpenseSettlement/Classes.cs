// See https://aka.ms/new-console-template for more information
public record Transaction(string From, string To, int Amount)
{
    override public string ToString() => $"{From} owes {To} {Amount}";
}

public record ExpensePaidBy(string Name, int Amount);

public record ExpenseSharedBy(string Name, int Amount);

public record UserForPriorityQueue(string Name, int Amount);