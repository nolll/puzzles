using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody06;

[Name("The Tree of Titans")]
public class Everybody06 : EverybodyPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var result = Part1(input);
        return new PuzzleResult(result, "1e1f24ab14407ffbaf4f6b9143384384");
    }
    
    protected override PuzzleResult RunPart2(string input)
    {
        var result = Part2And3(input);
        return new PuzzleResult(result, "aaacecff7b5d20d54ea2d96c4797166e");
    }
    
    protected override PuzzleResult RunPart3(string input)
    {
        var result = Part2And3(input);
        return new PuzzleResult(result, "c3544a49e37c3dfedc6dec99596402da");
    }

    public static string Part1(string input) => string.Join("", Run(input));
    public static string Part2And3(string input) => string.Join("", Run(input).Select(o => o[0]));

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