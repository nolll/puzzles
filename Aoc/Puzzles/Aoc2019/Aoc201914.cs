using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Space Stoichiometry")]
public class Aoc201914 : AocPuzzle
{
    [Puzzle("4f7b51a9155bea7c24bbb1d4757e4bf1")]
    public long Part1(string input)
    {
        var reactor = new NanoReactor(input);
        reactor.Run();
        return reactor.RequiredOreForOneFuel;
    }

    [Puzzle("d2bf7b83647cf534681bd96e1a53db40")]
    public long Part2(string input)
    {
        var reactor = new NanoReactor(input);
        reactor.Run();
        return reactor.FuelFromOneTrillionOre;
    }

    public class NanoReactor
    {
        private readonly IList<Reaction> _reactions;
        private readonly IDictionary<string, long> _storage;
        private readonly IDictionary<string, Reaction> _recipes;
        private long _fuelCount;

        public long RequiredOreForOneFuel { get; private set; }
        public long FuelFromOneTrillionOre { get; private set; }

        public NanoReactor(string input)
        {
            _reactions = new ReactionParser().Parse(input);
            _storage = new Dictionary<string, long>();
            _recipes = new Dictionary<string, Reaction>();

            _storage.Add("ORE", 1_000_000_000_000);
            foreach (var reaction in _reactions)
            {
                _recipes.Add(reaction.Output.Name, reaction);
                _storage.Add(reaction.Output.Name, 0);
            }
        }

        public void Run()
        {
            MakeFuel(1);
            const long oreLimit = 1_000_000_000_000;
            RequiredOreForOneFuel = oreLimit - _storage["ORE"];
            long batchSize = 1;

            while (_storage["ORE"] > 0 && batchSize > 0)
            {
                batchSize = (long)Math.Floor((double)_storage["ORE"] / RequiredOreForOneFuel);
                MakeFuel(batchSize);
            }

            while (_storage["ORE"] > 0)
            {
                try
                {
                    MakeFuel(1);
                }
                catch
                {
                    break;
                }
            }

            FuelFromOneTrillionOre = _fuelCount;
        }

        private void MakeFuel(long quantity)
        {
            var fuel = Get("FUEL", quantity);
            _fuelCount += fuel.Quantity;
        }

        private ChemicalQuantity Get(string name, long quantity)
        {
            var inStorage = _storage[name];
            if (inStorage < quantity)
            {
                var amountToMake = quantity - inStorage;
                Make(name, amountToMake);
            }

            RemoveFromStorage(name, quantity);
            return new ChemicalQuantity(name, quantity);
        }

        private void Make(string name, long quantity)
        {
            var recipe = _recipes[name];
            foreach (var input in recipe.Inputs)
            {
                var cq = Get(input.Name, input.Quantity * (long)Math.Ceiling((double)quantity / recipe.Output.Quantity));
            }

            AddToStorage(name, recipe.Output.Quantity * (long)Math.Ceiling((double)quantity / recipe.Output.Quantity));
        }

        private void AddToStorage(string name, long quantity)
        {
            var inStorage = _storage[name];
            _storage[name] = inStorage + quantity;
        }

        private void RemoveFromStorage(string name, long quantity)
        {
            var inStorage = _storage[name];
            _storage[name] = inStorage - quantity;
        }
    }
    
    public record ChemicalQuantity(string Name, long Quantity);
    public record Reaction(ChemicalQuantity Output, IList<ChemicalQuantity> Inputs);
    
    public class ReactionParser
    {
        public IList<Reaction> Parse(string input)
        {
            var rows = input.Trim().Split(LineBreaks.Single).Select(o => o.Trim());
            var reactions = new List<Reaction>();
            foreach (var row in rows)
            {
                var parts = row.Trim().Split("=>").Select(o => o.Trim()).ToList();
                var inputPart = parts[0].Trim();
                var outputPart = parts[1].Trim();
                var inputQuantities = inputPart.Split(',').Select(ParseQuantity).ToList();
                var outputQuantity = ParseQuantity(outputPart);
                reactions.Add(new Reaction(outputQuantity, inputQuantities));
            }
            return reactions;
        }

        private ChemicalQuantity ParseQuantity(string input)
        {
            var parts = input.Trim().Split(' ').ToList();
            var quantity = int.Parse(parts[0].Trim());
            var name = parts[1].Trim();
            return new ChemicalQuantity(name, quantity);
        }
    }
}