using System.Diagnostics;
using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Nullspiracy")]
public class Ece202606 : EverybodyEventPuzzle
{
    [Puzzle("3c0e33401e7256342a29ad84f59b7fc9")]
    public int Part1(string input)
    {
        var ingredients = new Dictionary<string, List<string>>();
        var lines = input.Split(LineBreaks.Single);
        foreach (var line in lines)
        {
            var (name, childrenString) = line.Split(':');
            var children = childrenString.Split(',');
            ingredients.TryAdd(name, []);
            foreach (var child in children)
            {
                ingredients.TryAdd(child, []);
                ingredients[name].Add(child);
            }
        }

        HashSet<string> seen = ["NULL"];
        TraceIngredients(ingredients, "NULL", seen);
        
        return seen.Count - 1;
    }

    private void TraceIngredients(Dictionary<string, List<string>> ingredients, string name, HashSet<string> seen)
    {
        foreach (var child in ingredients[name])
        {
            if (seen.Add(child)) 
                TraceIngredients(ingredients, child, seen);
        }
    }

    [Puzzle("118a028c800a133c27471f26d6cb5bc3")]
    public int Part2(string input)
    {
        var ingredients = new Dictionary<string, List<string>>();
        var lines = input.Split(LineBreaks.Single);
        foreach (var line in lines)
        {
            var (parent, childrenString) = line.Split(':');
            var children = childrenString.Split(',');
            ingredients.TryAdd(parent, []);
            foreach (var child in children)
            {
                ingredients.TryAdd(child, []);
                ingredients[child].Add(parent);
            }
        }

        HashSet<string> seen = ["NULL"];
        TraceIngredients(ingredients, "NULL", seen);
        
        return seen.Count - 1;
    }

    [Puzzle("2ad4f38adba07e508a7c0330b614d782")]
    public int Part3(string input)
    {
        var ingredients = new Dictionary<string, List<string>>();
        var lines = input.Split(LineBreaks.Single);
        var roots = new List<string>();
        foreach (var line in lines)
        {
            var (name, childrenString) = line.Split(':');
            var children = childrenString.Split(',');
            roots.Add(name);
            ingredients.TryAdd(name, []);
            foreach (var child in children)
            {
                ingredients.TryAdd(child, []);
                ingredients[name].Add(child);
            }
        }

        var count = 0;
        foreach (var root in roots)
        {
            HashSet<string> seen = [root];
            TraceIngredients(ingredients, root, seen);
            if (seen.Count(o => o.StartsWith("NULLv")) >= 2)
                count++;
        }
        
        return count;
    }
}