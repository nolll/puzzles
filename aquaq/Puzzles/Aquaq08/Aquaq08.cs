using Common.Puzzles;
using System;
using System.IO;

namespace Aquaq.Puzzles.Aquaq08;

public class Aquaq08 : AquaqPuzzle
{
    public override string Name => "Cron Flakes";

    protected override PuzzleResult Run()
    {
        var (milk, cereal) = Run(InputFile);
        var sum = milk + cereal;

        return new PuzzleResult(sum);
    }

    public static (int milk, int cereal) Run(string input)
    {
        var days = input.Split(Environment.NewLine)
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

        var time = 1;
        foreach (var day in days)
        {
            // buy cereal
            if (day.Cereal > 0)
                cereals.Add(new Cereal(day.Cereal));

            // have breakfast
            if (milks.Any(o => o.Amount > 0) && cereals.Any(o => o.Amount > 0))
            {
                milks.First().Consume();
                cereals.First().Consume();
            }

            // milk ages one day
            foreach (var milk in milks)
                milk.IncreaseAge();

            // buy milk
            if (day.Milk > 0)
                milks.Add(new Milk(day.Milk, 0));

            milks = milks.Where(o => o.Age < 5 && o.Amount > 0).OrderByDescending(o => o.Age).ToList();
            cereals = cereals.Where(o => o.Amount > 0).ToList();

            Console.WriteLine($"{day.DateTime.ToShortDateString()} {milks.Sum(o => o.Amount)} {cereals.Sum(o => o.Amount)}");

            time++;
        }

        var totalMilk = milks.Sum(o => o.Amount);
        var totalCereal = cereals.Sum(o => o.Amount);
        return (totalMilk, totalCereal);
    }
}

public class Day
{
    public DateTime DateTime { get; }
    public int Milk { get; }
    public int Cereal { get; }

    public Day(DateTime dateTime, int milk, int cereal)
    {
        DateTime = dateTime;
        Milk = milk;
        Cereal = cereal;
    }
}

public class Milk
{
    public int Amount { get; private set; }
    public int Age { get; private set; }

    public Milk(int amount, int age)
    {
        Amount = amount;
        Age = age;
    }

    public void IncreaseAge()
    {
        Age++;
    }

    public void Consume()
    {
        Amount -= 100;
    }

    public void ThrowAway()
    {
        Amount = 0;
    }
}

public class Cereal
{
    public int Amount { get; private set; }

    public Cereal(int amount)
    {
        Amount = amount;
    }

    public void Consume()
    {
        Amount -= 100;
    }
}