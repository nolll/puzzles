using System.Collections.Generic;

namespace Core.MakeFuel
{
    public class Reaction
    {
        public ChemicalQuantity Output { get; }
        public IList<ChemicalQuantity> Input { get; }

        public Reaction(ChemicalQuantity output, IList<ChemicalQuantity> input)
        {
            Output = output;
            Input = input;
        }
    }
}