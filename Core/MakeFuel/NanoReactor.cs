using System.Collections.Generic;
using System.Linq;

namespace Core.MakeFuel
{
    public class NanoReactor
    {
        private readonly IList<Reaction> _reactions;
        private readonly IDictionary<string, ChemicalQuantity> _waste;
        private readonly IDictionary<string, int> _storage;
        private readonly IDictionary<string, Reaction> _recipes;
        private int _oreCount;

        public NanoReactor(string input)
        {
            _oreCount = 0;
            _reactions = new ReactionParser().Parse(input);
            _waste = new Dictionary<string, ChemicalQuantity>();
            _storage = new Dictionary<string, int>();
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

        public int GetRequiredOre()
        {
            var fuel = Get("FUEL", 1).Quantity;
            return _oreCount;
        }

        private ChemicalQuantity Get(string name, int quantity)
        {
            var inStorage = _storage[name];
            while (inStorage < quantity)
            {
                Make(name);
                inStorage = _storage[name];
            }

            if(name != "FUEL")
                RemoveFromStorage(name, quantity);
            return new ChemicalQuantity(name, quantity);
        }

        private void Make(string name)
        {
            if (name == "ORE")
            {
                _oreCount += 1;
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

        private void AddToStorage(string name, int quantity)
        {
            var inStorage = _storage[name];
            _storage[name] = inStorage + quantity;
        }

        private void RemoveFromStorage(string name, int quantity)
        {
            var inStorage = _storage[name];
            _storage[name] = inStorage - quantity;
        }
    }
}