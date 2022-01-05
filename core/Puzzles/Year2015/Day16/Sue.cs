using System.Collections.Generic;

namespace Core.Puzzles.Year2015.Day16;

public class Sue
{
    private readonly IDictionary<string, int> _properties;
    public int Number { get; }

    public Sue(int number)
    {
        Number = number;
        _properties = new Dictionary<string, int>();
    }

    public void Set(string name, int amount)
    {
        _properties.Add(name, amount);
    }

    public bool IsCorrectSuePart1 =>
        IsNullOrEqual("children", 3) &&
        IsNullOrEqual("cats", 7) &&
        IsNullOrEqual("samoyeds", 2) &&
        IsNullOrEqual("pomeranians", 3) &&
        IsNullOrEqual("akitas", 0) &&
        IsNullOrEqual("vizslas", 0) &&
        IsNullOrEqual("goldfish", 5) &&
        IsNullOrEqual("trees", 3) &&
        IsNullOrEqual("cars", 2) &&
        IsNullOrEqual("perfumes", 1);

    public bool IsCorrectSuePart2 =>
        IsNullOrEqual("children", 3) &&
        IsNullOrGreaterThan("cats", 7) &&
        IsNullOrEqual("samoyeds", 2) &&
        IsNullOrLessThan("pomeranians", 3) &&
        IsNullOrEqual("akitas", 0) &&
        IsNullOrEqual("vizslas", 0) &&
        IsNullOrLessThan("goldfish", 5) &&
        IsNullOrGreaterThan("trees", 3) &&
        IsNullOrEqual("cars", 2) &&
        IsNullOrEqual("perfumes", 1);

    private bool IsNullOrEqual(string name, int amount)
    {
        var hasKey = _properties.ContainsKey(name);
        return !hasKey || _properties[name] == amount;
    }

    private bool IsNullOrGreaterThan(string name, int amount)
    {
        var hasKey = _properties.ContainsKey(name);
        return !hasKey || _properties[name] > amount;
    }

    private bool IsNullOrLessThan(string name, int amount)
    {
        var hasKey = _properties.ContainsKey(name);
        return !hasKey || _properties[name] < amount;
    }
}