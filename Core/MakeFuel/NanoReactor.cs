using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.MakeFuel
{
    public class NanoReactor
    {
        private readonly IList<Reaction> _reactions;
        private readonly IDictionary<string, ChemicalQuantity> _waste;
        private readonly IDictionary<string, long> _storage;
        private readonly IDictionary<string, Reaction> _recipes;
        private long _fuelCount;
        private long? _availableOre;

        public long RequiredOreForOneFuel { get; private set; }
        public long OreCount { get; private set; }

        public NanoReactor(string input)
        {
            OreCount = 0;
            _reactions = new ReactionParser().Parse(input);
            _waste = new Dictionary<string, ChemicalQuantity>();
            _storage = new Dictionary<string, long>();
            _recipes = new Dictionary<string, Reaction>();

            _storage.Add("ORE", 0);
            foreach (var reaction in _reactions)
            {
                _recipes.Add(reaction.Output.Name, reaction);
                _storage.Add(reaction.Output.Name, 0);
            }
        }

        public void Run()
        {
            var fuel = GetFuel(1);
            RequiredOreForOneFuel = OreCount;
            var oreLimit = 1000000000000;
            var nextFuelLevel = oreLimit / RequiredOreForOneFuel;
        }

        private ChemicalQuantity GetFuel(long quantity)
        {
            var fuel = Get("FUEL", quantity);
            _fuelCount += quantity;
            return fuel;
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

        private void Make(string name)
        {
            if (name == "ORE")
            {
                var newOreCount = OreCount + 1;
                if (_availableOre != null && newOreCount > _availableOre.Value)
                {
                    throw new OutOfOresException();
                }
                OreCount = newOreCount;
                AddToStorage(name, 1);
            }
            else
            {
                var recipe = _recipes[name];
                foreach (var input in recipe.Inputs)
                {
                    var cq = Get(input.Name, input.Quantity);
                }
                AddToStorage(name, recipe.Output.Quantity);
            }
        }

        private void Make(string name, long quantity)
        {
            if (name == "ORE")
            {
                var newOreCount = OreCount + quantity;
                OreCount = newOreCount;
                AddToStorage(name, quantity);
            }
            else
            {
                var recipe = _recipes[name];
                foreach (var input in recipe.Inputs)
                {
                    var cq = Get(input.Name, input.Quantity * (long)Math.Ceiling((double)quantity / recipe.Output.Quantity));
                }
                AddToStorage(name, recipe.Output.Quantity * (long)Math.Ceiling((double)quantity / recipe.Output.Quantity));
            }
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

    public class OutOfOresException : Exception
    {
    }
}