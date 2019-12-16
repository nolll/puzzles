using System;
using System.Collections.Generic;

namespace Core.MakeFuel
{
    public class NanoReactor2
    {
        private readonly IList<Reaction> _reactions;
        private IDictionary<string, long> _storage;
        private IDictionary<string, Reaction> _recipes;
        public long OreCount { get; set; }
 
        public NanoReactor2(string input)
        {
            OreCount = 0;
            _reactions = new ReactionParser().Parse(input);
            Init();
        }

        private void Init()
        {
            _storage = new Dictionary<string, long>();
            _recipes = new Dictionary<string, Reaction>();
            _storage.Add("ORE", 0);
            foreach (var reaction in _reactions)
            {
                _recipes.Add(reaction.Output.Name, reaction);
                _storage.Add(reaction.Output.Name, 0);
            }
        }

        public void MakeFuel(long count)
        {
            Get("FUEL", count);
            var x = 0;
        }

        public long FuelFor(long target)
        {
            var lowerFuel = 1;
            var lastFuel = Get("FUEL", 1).Quantity;
            var currentOreCount = OreCount;
            var upperFuel = (int)(target / currentOreCount) * 2;
            while (true)
            {
                var currentFuel = lowerFuel + (upperFuel - lowerFuel) / 2;
                if (currentFuel == lastFuel)
                    break;
                Init();
                var _ = Get("FUEL", currentFuel).Quantity;
                if (OreCount < target)
                {
                    lowerFuel = currentFuel;
                }
                else if (OreCount > target)
                {
                    upperFuel = currentFuel;
                }
            }

            return lastFuel;
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
}