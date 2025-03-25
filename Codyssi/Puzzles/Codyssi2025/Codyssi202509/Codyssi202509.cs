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
            officials[from].PayPlain(officials[to], amount);
        }

        var sum = officials.Values.Select(o => o.Balance).OrderDescending().Take(3).Sum();
        
        return new PuzzleResult(sum, "f2d434aaa0fe259865b9d9cfe1d06f6f");
    }

    public PuzzleResult Part2(string input)
    {
        var (officials, transactions) = Parse(input);

        foreach (var (from, to, amount) in transactions)
        {
            officials[from].PayLimited(officials[to], amount);
        }

        var sum = officials.Values.Select(o => o.Balance).OrderDescending().Take(3).Sum();
        
        return new PuzzleResult(sum, "df8f313313f13f9a6361b0c692e92061");
    }

    public PuzzleResult Part3(string input)
    {
        var (officials, transactions) = Parse(input);
        
        foreach (var (from, to, amount) in transactions)
        {
            officials[from].PayWithDebt(officials[to], amount);
        }
        
        var sum = officials.Values.Select(o => o.Balance).OrderDescending().Take(3).Sum();
        
        return new PuzzleResult(sum, "2636591baa425722553a06d9e6e95dd3");
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
        private List<Debt> _debts = [];
        public int Balance { get; private set; } = balance;

        public void PayPlain(Official recipient, int amount)
        {
            Balance -= amount;
            recipient.RecievePlain(amount);
        }
        
        public void PayLimited(Official recipient, int amount)
        {
            var amt = Math.Min(amount, Balance);
            Balance -= amt;
            recipient.RecievePlain(amt);
        }
        
        public void PayWithDebt(Official recipient, int amount)
        {
            var prevBalance = Balance;
            if (Balance >= amount)
            {
                Balance -= amount;
                recipient.RecieveWithDebt(amount);
                return;
            }

            Balance = 0;
            recipient.RecieveWithDebt(prevBalance);
            _debts.Add(new Debt(recipient, amount - prevBalance));
        }

        private void RecieveWithDebt(int amount)
        {
            while (amount > 0 && _debts.Count(o => o.Amount > 0) > 0)
            {
                var debt = _debts.First(o => o.Amount > 0);
                if (debt.Amount > amount)
                {
                    debt.Amount -= amount;
                    debt.Creditor.RecieveWithDebt(amount);
                    amount = 0;
                }
                else
                {
                    amount -= debt.Amount;
                    var amountToPay = debt.Amount;
                    debt.Amount = 0;
                    debt.Creditor.RecieveWithDebt(amountToPay);
                }

                _debts = _debts.Where(o => o.Amount > 0).ToList();
            }

            Balance += amount;
        }

        private void RecievePlain(int amount) => Balance += amount;
    }

    private class Debt(Official creditor, int amount)
    {
        public Official Creditor { get; } = creditor;
        public int Amount { get; set; } = amount;
    }
}