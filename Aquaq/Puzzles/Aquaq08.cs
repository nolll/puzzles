using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles;

[Name("Cron Flakes")]
public class Aquaq08 : AquaqPuzzle
{
    [Puzzle("dd27abc4b9d9ddead1ae574a69b3edbc")]
    public int Solve(string input)
    {
        var (milk, cereal) = RunInternal(input);
        return milk + cereal;
    }

    public static (int milk, int cereal) RunInternal(string input)
    {
        var days = input.Split(LineBreaks.Single)
            .Skip(1)
            .Select(o =>
            {
                var parts = o.Split(',');
                var dateTime = DateTime.Parse(parts[0]);
                var milk = int.Parse(parts[1]);
                var cereal = int.Parse(parts[02]);
                return new Day(dateTime, milk, cereal);
            }).ToList();

        days.Add(new Day(days.Last().DateTime.AddDays(1), 0, 0));

        var milks = new List<Milk>();
        var cereals = new List<Cereal>();

        var morningTotalMilk = 0;
        var morningTotalCereal = 0;

        foreach (var day in days)
        {
            morningTotalMilk = milks.Sum(o => o.Amount);
            morningTotalCereal = cereals.Sum(o => o.Amount);

            if (day.CerealAmount > 0)
                cereals.Add(new Cereal(day.CerealAmount));

            if (milks.Any(o => o.Amount > 0) && cereals.Any(o => o.Amount > 0))
            {
                milks.First().Consume();
                cereals.First().Consume();
            }

            foreach (var milk in milks)
                milk.IncreaseAge();

            if (day.MilkAmount > 0)
                milks.Add(new Milk(day.MilkAmount));

            milks = milks.Where(o => o is { Age: < 5, Amount: > 0 }).OrderByDescending(o => o.Age).ToList();
            cereals = cereals.Where(o => o.Amount > 0).ToList();
        }

        return (morningTotalMilk, morningTotalCereal);
    }

    private abstract class Product(int amount)
    {
        public int Amount { get; private set; } = amount;
        public void Consume() => Amount -= 100;
    }

    private abstract class AgeingProduct(int amount) : Product(amount)
    {
        public int Age { get; private set; }
        public void IncreaseAge() => Age++;
    }

    private class Cereal(int amount) : Product(amount);
    private class Milk(int amount) : AgeingProduct(amount);

    private class Day(DateTime dateTime, int milkAmount, int cerealAmount)
    {
        public DateTime DateTime { get; } = dateTime;
        public int MilkAmount { get; } = milkAmount;
        public int CerealAmount { get; } = cerealAmount;
    }
}