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
        private long _oreCount;
        private int _fuelCount;
        private long? _availableOre;

        public NanoReactor(string input)
        {
            _oreCount = 0;
            _reactions = new ReactionParser().Parse(input);
            _waste = new Dictionary<string, ChemicalQuantity>();
            _storage = new Dictionary<string, long>();
            _recipes = new Dictionary<string, Reaction>();
            Init();
        }

        private void Init()
        {
            _storage.Add("ORE", 0);
            foreach (var reaction in _reactions)
            {
                _recipes.Add(reaction.Output.Name, reaction);
                _storage.Add(reaction.Output.Name, 0);
            }
        }

        public long GetRequiredOreForOneFuel()
        {
            var fuel = GetOneFuel();
            return _oreCount;
        }

        public long GetRequiredOreFor1000Fuel()
        {
            for (var i = 0; i < 1000; i++)
            {
                GetOneFuel();
            }

            return _oreCount;
        }

        public int GetUntilOutOfOre(long availableOre)
        {
            _availableOre = availableOre;
            while (true)
            {
                try
                {
                    GetOneFuel();
                    Console.WriteLine($"Fuel Count: {_fuelCount}, Ore Count: {_oreCount}");
                }
                catch (OutOfOresException)
                {
                    break;
                }
            }

            return _fuelCount;
        }

        private ChemicalQuantity GetOneFuel()
        {
            var fuel = Get("FUEL", 1);
            _fuelCount += 1;
            return fuel;
        }

        public ChemicalQuantity GetXFuel(int x)
        {
            var fuel = Get("FUEL", x);
            _fuelCount += 1;
            return fuel;
        }

        private ChemicalQuantity Get(string name, long quantity)
        {
            var inStorage = _storage[name];
            while (inStorage < quantity)
            {
                Make(name);
                inStorage = _storage[name];
            }

            RemoveFromStorage(name, quantity);
            return new ChemicalQuantity(name, quantity);
        }

        private void Make(string name)
        {
            if (name == "ORE")
            {
                var newOreCount = _oreCount + 1;
                if (_availableOre != null && newOreCount > _availableOre.Value)
                {
                    throw new OutOfOresException();
                }
                _oreCount = newOreCount;
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