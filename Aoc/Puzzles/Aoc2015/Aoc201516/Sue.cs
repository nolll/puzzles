namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201516;

public class Sue(int number)
{
    private readonly IDictionary<string, int> _properties = new Dictionary<string, int>();
    public int Number { get; } = number;

    public void Set(string name, int amount) => _properties.Add(name, amount);

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

    private bool IsNullOrEqual(string name, int amount) => 
        !_properties.ContainsKey(name) || _properties[name] == amount;

    private bool IsNullOrGreaterThan(string name, int amount) => 
        !_properties.ContainsKey(name) || _properties[name] > amount;

    private bool IsNullOrLessThan(string name, int amount) => 
        !_properties.ContainsKey(name) || _properties[name] < amount;
}