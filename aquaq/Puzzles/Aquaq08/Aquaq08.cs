using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq08;

public class Aquaq08 : AquaqPuzzle
{
    public override string Name => "Cron Flakes";

    protected override PuzzleResult Run()
    {
        var (milk, cereal) = Run(InputFile);
        var sum = milk + cereal;

        return new PuzzleResult(sum, "1e6e0a04d20f50967c64dac2d639a577");
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

        var morningTotalMilk = 0;
        var morningTotalCereal = 0;

        foreach (var day in days)
        {
            morningTotalMilk = milks.Sum(o => o.Amount);
            morningTotalCereal = cereals.Sum(o => o.Amount);

            if (day.Cereal > 0)
                cereals.Add(new Cereal(day.Cereal));

            if (milks.Any(o => o.Amount > 0) && cereals.Any(o => o.Amount > 0))
            {
                milks.First().Consume();
                cereals.First().Consume();
            }

            foreach (var milk in milks)
                milk.IncreaseAge();

            if (day.Milk > 0)
                milks.Add(new Milk(day.Milk));

            milks = milks.Where(o => o is { Age: < 5, Amount: > 0 }).OrderByDescending(o => o.Age).ToList();
            cereals = cereals.Where(o => o.Amount > 0).ToList();
        }

        return (morningTotalMilk, morningTotalCereal);
    }
}