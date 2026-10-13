using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Space Stoichiometry")]
public class Aoc201914 : AocPuzzle
{
    [Puzzle("4f7b51a9155bea7c24bbb1d4757e4bf1")]
    public long Part1(string input)
    {
        var (requiredOreForOneFuel, _) = Solve(input);
        return requiredOreForOneFuel;
    }

    [Puzzle("d2bf7b83647cf534681bd96e1a53db40")]
    public long Part2(string input)
    {
        var (_, fuelCount) = Solve(input);
        return fuelCount;
    }

    private (Dictionary<string, long> _storage, Dictionary<string, Reaction> _recipes) Init(string input)
    {
        var reactions = Parse(input);
        var storage = new Dictionary<string, long>();
        var recipes = new Dictionary<string, Reaction>();

        storage.Add("ORE", 1_000_000_000_000);
        foreach (var reaction in reactions)
        {
            recipes.Add(reaction.Output.Name, reaction);
            storage.Add(reaction.Output.Name, 0);
        }

        return (storage, recipes);
    }

    private (long RequiredOreForOneFuel, long fuelCount) Solve(string input)
    {
        var (storage, recipes) = Init(input);
        var fuelCount = 0L;
        fuelCount += MakeFuel(storage, recipes, 1);
        const long oreLimit = 1_000_000_000_000;
        var requiredOreForOneFuel = oreLimit - storage["ORE"];
        long batchSize = 1;

        while (storage["ORE"] > 0 && batchSize > 0)
        {
            batchSize = (long)Math.Floor((double)storage["ORE"] / requiredOreForOneFuel);
            fuelCount += MakeFuel(storage, recipes, batchSize);
        }

        while (storage["ORE"] > 0)
        {
            try
            {
                fuelCount += MakeFuel(storage, recipes, 1);
            }
            catch
            {
                break;
            }
        }

        return (requiredOreForOneFuel, fuelCount);
    }

    private long MakeFuel(Dictionary<string, long> storage, Dictionary<string, Reaction> recipes, long quantity) => 
        Get(storage, recipes, "FUEL", quantity).Quantity;

    private ChemicalQuantity Get(Dictionary<string, long> storage, Dictionary<string, Reaction> recipes, string name, long quantity)
    {
        var inStorage = storage[name];
        if (inStorage < quantity)
        {
            var amountToMake = quantity - inStorage;
            Make(storage, recipes, name, amountToMake);
        }

        RemoveFromStorage(storage, name, quantity);
        return new ChemicalQuantity(name, quantity);
    }

    private void Make(Dictionary<string, long> storage, Dictionary<string, Reaction> recipes, string name, long quantity)
    {
        var recipe = recipes[name];
        foreach (var input in recipe.Inputs)
        {
            Get(storage, recipes, input.Name, input.Quantity * (long)Math.Ceiling((double)quantity / recipe.Output.Quantity));
        }

        AddToStorage(storage, name, recipe.Output.Quantity * (long)Math.Ceiling((double)quantity / recipe.Output.Quantity));
    }

    private static void AddToStorage(Dictionary<string, long> storage, string name, long quantity) => storage[name] += quantity;
    private static void RemoveFromStorage(Dictionary<string, long> storage, string name, long quantity) => storage[name] -= quantity;

    public record ChemicalQuantity(string Name, long Quantity);
    public record Reaction(ChemicalQuantity Output, IList<ChemicalQuantity> Inputs);
    
    public static IList<Reaction> Parse(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        var reactions = new List<Reaction>();
        foreach (var row in rows)
        {
            var (inputPart, outputPart) = row.Split("=>");
            var inputQuantities = inputPart.Split(',').Select(ParseQuantity).ToList();
            var outputQuantity = ParseQuantity(outputPart);
            reactions.Add(new Reaction(outputQuantity, inputQuantities));
        }

        return reactions;
    }

    private static ChemicalQuantity ParseQuantity(string input)
    {
        var parts = input.Trim().Split(' ').ToList();
        var quantity = int.Parse(parts[0]);
        var name = parts[1];
        return new ChemicalQuantity(name, quantity);
    }
}