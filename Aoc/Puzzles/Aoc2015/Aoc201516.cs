using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Aunt Sue")]
public class Aoc201516 : AocPuzzle
{
    [Puzzle("fc9e347f58cd62a8056800cedf1772ff")]
    public int Part1(string input) => ParseSues(input).FirstOrDefault(o => o.IsCorrectSuePart1)?.Number ?? 0;

    [Puzzle("d0cfc435d1459e83bcc2be3046271a1a")]
    public int Part2(string input) => ParseSues(input).FirstOrDefault(o => o.IsCorrectSuePart2)?.Number ?? 0;

    private static Sue[] ParseSues(string input) => [.. input.Split(LineBreaks.Single).Select(ParseSue)];
    
    private static Sue ParseSue(string s)
    {
        var (_, id, name1, value1, name2, value2, name3, value3) = s.Replace(":", "").Replace(",", "").Split(' ');
        var number = int.Parse(id);
        var sue = new Sue(number);
        sue.Set(name1, int.Parse(value1));
        sue.Set(name2, int.Parse(value2));
        sue.Set(name3, int.Parse(value3));
        return sue;
    }

    private class Sue(int number)
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
}