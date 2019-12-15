using System.Collections.Generic;
using System.Linq;

namespace Core.MakeFuel
{
    public class NanoReactor
    {
        private readonly IList<Reaction> _reactions;.
        private readonly IDictionary<string, ChemicalQuantity> _waste;

        public NanoReactor(string input)
        {
            _reactions = new ReactionParser().Parse(input);
            _waste = new Dictionary<string, ChemicalQuantity>();
        }

        public int GetRequiredOre()
        {
            var fuelReaction = FindReactionByOutputName("FUEL");
            var inputOres = GetNextLevelInputs(fuelReaction.Inputs, 1);
            return inputOres.Sum(o => o.Quantity);
        }

        private IEnumerable<ChemicalQuantity> GetNextLevelInputs(IEnumerable<ChemicalQuantity> inputs, int multiplier)
        {
            foreach (var input in inputs)
            {
                if (input.Name == "ORE")
                {
                    yield return new ChemicalQuantity(input.Name, input.Quantity * multiplier);
                }
                else
                {
                    var r = FindReactionByOutputName(input.Name);
                    var x = GetNextLevelInputs(r.Inputs, multiplier);
                    foreach (var y in x)
                    {
                        yield return y;
                    }
                }
            }
        }

        private ChemicalQuantity TakeFromWaste(string name, int quantity)
        {
            if (_waste.TryGetValue(name, out var c))
            {
                if (c.Quantity >= quantity)
                {
                    var leftInWaste = c.Quantity - quantity;
                    _waste[name] = new ChemicalQuantity(name, leftInWaste);
                    return new ChemicalQuantity(name, quantity);
                }
            }

            return null;
        }

        private Reaction FindReactionByOutputName(string name)
        {
            return _reactions.First(o => o.Output.Name == name);
        }
    }
}