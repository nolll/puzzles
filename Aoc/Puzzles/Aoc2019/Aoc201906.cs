using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Universal Orbit Map")]
public class Aoc201906 : AocPuzzle
{
    [Puzzle("47b7e7a9aac22c8d0dc3f8a1f510498a")]
    public int Part1(string input) => BuildDictionary(input).Values.Sum(o => o.OrbitCount);

    [Puzzle("b69467aeda98c0291c1767a24409e868")]
    public int Part2(string input)
    {
        var dictionary = BuildDictionary(input);
        var youPath = dictionary["YOU"].ParentPath;
        var santaPath = dictionary["SAN"].ParentPath;

        return $"{youPath}|{santaPath}".Split('|')
            .GroupBy(o => o)
            .Count(o => o.Key != "SAN" && o.Key != "YOU" && o.Count() == 1);
    }

    private static Dictionary<string, Body> BuildDictionary(string input)
    {
        var items = input.Trim().Split(LineBreaks.Single).Select(o => o.Trim());
        var dictionary = new Dictionary<string, Body>();
        foreach (var item in items)
        {
            var (parentName, childName) = item.Split(')');

            if (!dictionary.TryGetValue(parentName, out var parent))
            {
                parent = new Body(parentName);
                dictionary.Add(parentName, parent);
            }

            if (!dictionary.TryGetValue(childName, out var child))
            {
                child = new Body(childName);
                dictionary.Add(childName, child);
            }

            child.Parent ??= parent;
        }

        return dictionary;
    }

    public class Body(string name)
    {
        public Body? Parent { get; set; }
        public int OrbitCount => Parent == null ? 0 : Parent.OrbitCount + 1;

        public string ParentPath
        {
            get => Parent == null ? field : $"{Parent.ParentPath}|{field}";
        } = name;
    }
}