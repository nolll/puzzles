using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202509;

[Name("Windy Bargain")]
public class Codyssi202509 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var (officials, transactions) = Parse(input);

        foreach (var (from, to, amount) in transactions)
        {
            officials[from].Balance -= amount;
            officials[to].Balance += amount;
        }

        var sum = officials.Values.Select(o => o.Balance).OrderDescending().Take(3).Sum();
        
        return new PuzzleResult(sum, "f2d434aaa0fe259865b9d9cfe1d06f6f");
    }

    public PuzzleResult Part2(string input)
    {
        var (officials, transactions) = Parse(input);

        foreach (var (from, to, amount) in transactions)
        {
            var amt = Math.Min(amount, officials[from].Balance);
            officials[from].Balance -= amt;
            officials[to].Balance += amt;
        }

        var sum = officials.Values.Select(o => o.Balance).OrderDescending().Take(3).Sum();
        
        return new PuzzleResult(sum, "df8f313313f13f9a6361b0c692e92061");
    }

    public PuzzleResult Part3(string input)
    {
        // var (officials, transactions) = Parse(input);
        //
        // foreach (var (from, to, amount) in transactions)
        // {
        //     var amountToPay = amount;
        //     var amountToReceive = amount;
        //     if (officials[from].Balance >= amountToPay)
        //     {
        //         officials[from].Balance -= amountToPay;
        //     }
        //     else
        //     {
        //         amountToReceive = officials[from].Balance;
        //         var debt = amount - officials[from].Balance;
        //         officials[from].Balance = 0;
        //         officials[from].Debts.Add(new Debt(to, debt, officials[from].NextDebtPriority));
        //         officials[from].NextDebtPriority++;
        //     }
        //
        //     while (officials[to].HasDebt)
        //     {
        //         var debt = officials[to].Debts.First();
        //         if(debt.Amount)
        //     }
        //     
        //     
        // }
        //
        // var sum = officials.Values.Select(o => o.Balance).OrderDescending().Take(3).Sum();
        //
        return new PuzzleResult(0);
    }
    
    private static (
        Dictionary<string, Official> officials, 
        IEnumerable<(string from, string to, int amount)> transactions) Parse(string input)
    {
        var (a, b) = input.Split(LineBreaks.Double);
        var officials = a.Split(LineBreaks.Single)
            .Select(o => o.Split(" HAS "))
            .ToDictionary(k => k[0], v => new Official(int.Parse(v[1])));
        var transactions = b.Split(LineBreaks.Single)
            .Select(o => o.Split(" "))
            .Select(o => (from: o[1], to: o[3], amount: int.Parse(o[5])));

        return (officials, transactions);
    }

    private class Official(int balance)
    {
        public int Balance { get; set; } = balance;
        public List<Debt> Debts { get; set; } = [];
        public int NextDebtPriority { get; set; } = 0;
        public bool HasDebt => Debts.Count > 0;
    }

    private class Debt(string to, int amount, int priority)
    {
        public string To { get; } = to;
        public int Amount { get; set; } = amount;
        public int Priority { get; } = priority;
    }
}