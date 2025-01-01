namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201513;

public record DinnerGuest(string Name)
{
    private IList<DinnerGuestRule> Rules { get; } = new List<DinnerGuestRule>();

    public void AddRule(DinnerGuestRule rule) => Rules.Add(rule);
    public int GetHappiness(string otherName) => Rules.FirstOrDefault(o => o.Name == otherName)?.Happiness ?? 0;
}