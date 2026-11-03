using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Nullspiracy")]
public class Ece202606 : EverybodyEventPuzzle
{
    [Puzzle("3c0e33401e7256342a29ad84f59b7fc9")]
    public int Part1(string input) => CountIngredients(BuildIngredients(input, AddChild), "NULL") - 1;

    [Puzzle("118a028c800a133c27471f26d6cb5bc3")]
    public int Part2(string input) => CountIngredients(BuildIngredients(input, AddChildInverted), "NULL") - 1;

    [Puzzle("2ad4f38adba07e508a7c0330b614d782")]
    public int Part3(string input)
    {
        var ingredients = BuildIngredients(input, AddChild);
        return GetRoots(input).Count(root => GetIngredients(ingredients, root).Count(o => o.StartsWith("NULLv")) >= 2);
    }

    private int CountIngredients(Dictionary<string, List<string>> ingredients, string name) => GetIngredients(ingredients, name).Count;

    private List<string> GetIngredients(Dictionary<string, List<string>> ingredients, string name)
    {
        HashSet<string> seen = [name];
        TraceIngredients(ingredients, name, seen);
        return [.. seen];
    }
    
    private void TraceIngredients(Dictionary<string, List<string>> ingredients, string name, HashSet<string> seen)
    {
        foreach (var child in ingredients[name])
        {
            if (seen.Add(child))
                TraceIngredients(ingredients, child, seen);
        }
    }
    
    private static Dictionary<string, List<string>> BuildIngredients(
        string input,
        Action<Dictionary<string, List<string>>, string, string> addChild)
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
                addChild(ingredients, parent, child);
            }
        }

        return ingredients;
    }
    
    private static void AddChild(Dictionary<string, List<string>> ingredients, string parent, string child) => 
        ingredients[parent].Add(child);

    private static void AddChildInverted(Dictionary<string, List<string>> ingredients, string parent, string child) =>
        AddChild(ingredients, child, parent);
    
    private static List<string> GetRoots(string input) => input.Split(LineBreaks.Single).Select(o => o.Split(':')[0]).ToList();
}