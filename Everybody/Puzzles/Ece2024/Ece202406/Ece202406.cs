using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202406;

[Name("The Tree of Titans")]
public class Ece202406 : EverybodyEventPuzzle
{
    public PuzzleResult RunPart1(string input) => new(Part1(input), "1e1f24ab14407ffbaf4f6b9143384384");
    public PuzzleResult RunPart2(string input) => new(Part2And3(input), "aaacecff7b5d20d54ea2d96c4797166e");
    public PuzzleResult RunPart3(string input) => new(Part2And3(input), "c3544a49e37c3dfedc6dec99596402da");

    private static string Part1(string input) => string.Join("", Run(input));
    private static string Part2And3(string input) => string.Join("", Run(input).Select(o => o[0]));

    private static string[] Run(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var nodes = new Dictionary<string, string[]>();
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var name = parts[0];
            if(name is "ANT" or "BUG")
                continue;
            
            var children = parts[1].Split(',');
            nodes.Add(name, children);
        }
        
        return FindPaths(nodes, "RR", "")
            .Where(o => o.EndsWith('@'))
            .GroupBy(o => o.Length)
            .First(o => o.Count() == 1)
            .First()
            .Split(',', StringSplitOptions.RemoveEmptyEntries);
    }

    private static List<string> FindPaths(Dictionary<string,string[]> nodes, string name, string path)
    {
        var nextPath = $"{path},{name}";
        if (name == "@")
            return [nextPath];
        
        if(!nodes.TryGetValue(name, out var children))
            return [nextPath];

        var result = new List<string>();
        foreach (var child in children)
        {
            result.AddRange(FindPaths(nodes, child, nextPath));
        }

        return result;
    }
}