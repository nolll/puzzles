using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody06;

[Name("The Tree of Titans")]
public class Everybody06(string[] inputs) : EverybodyPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var result = RunPart1(inputs[0]);
        return new PuzzleResult(result, "1e1f24ab14407ffbaf4f6b9143384384");
    }
    
    protected override PuzzleResult RunPart2()
    {
        var result = RunPart2(inputs[1]);
        return new PuzzleResult(result, "aaacecff7b5d20d54ea2d96c4797166e");
    }
    
    protected override PuzzleResult RunPart3()
    {
        var result = RunPart3(inputs[2]);
        return new PuzzleResult(result, "c3544a49e37c3dfedc6dec99596402da");
    }

    public static string RunPart1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var nodes = new Dictionary<string, string[]>();
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var name = parts[0];
            var children = parts[1].Split(',');
            nodes.Add(name, children);
        }

        var paths = FindPaths(nodes, "RR", "");
        var r = paths.Where(o => o.EndsWith("@")).GroupBy(o => o.Length).ToList().First(o => o.Count() == 1).First();
        return r.Replace(",", "");
    }
    
    public static string RunPart2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var nodes = new Dictionary<string, string[]>();
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var name = parts[0];
            var children = parts[1].Split(',');
            nodes.Add(name, children);
        }

        var paths = FindPaths(nodes, "RR", "");
        var r = paths.Where(o => o.EndsWith("@")).GroupBy(o => o.Length).ToList().First(o => o.Count() == 1).First();
        return string.Join("", r.Split(",").Skip(1).Select(o => o[0]));
    }
    
    public static string RunPart3(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var nodes = new Dictionary<string, string[]>();
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var name = parts[0];
            var children = parts[1].Split(',');
            nodes.Add(name, children);
        }

        var paths = FindPaths(nodes, "RR", "", true);
        var r = paths.Where(o => o.EndsWith("@")).GroupBy(o => o.Length).ToList().First(o => o.Count() == 1).First();
        return string.Join("", r.Split(",").Skip(1).Select(o => o[0]));
    }

    private static List<string> FindPaths(Dictionary<string,string[]> nodes, string name, string path, bool ignoreBugs = false)
    {
        var nextPath = $"{path},{name}";
        if (name == "@")
            return [nextPath];
        
        if(!nodes.TryGetValue(name, out var children))
            return [nextPath];

        var result = new List<string>();
        var childrenToUse = ignoreBugs 
            ? children.Where(o => o != "ANT" && o != "BUG") 
            : children;
        foreach (var child in childrenToUse)
        {
            result.AddRange(FindPaths(nodes, child, nextPath, ignoreBugs));
        }

        return result;
    }
}