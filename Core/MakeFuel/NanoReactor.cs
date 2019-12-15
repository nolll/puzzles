using System.Collections.Generic;
using System.Linq;

namespace Core.MakeFuel
{
    public class NanoReactor
    {
        private IList<Reaction> _reactions;

        public NanoReactor(string input)
        {
            _reactions = new ReactionParser().Parse(input);
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

        private Reaction FindReactionByOutputName(string name)
        {
            return _reactions.First(o => o.Output.Name == name);
        }
    }
}